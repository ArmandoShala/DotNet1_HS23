Imports System
Imports System.Xml
Imports System.IO
Imports System.Windows.Forms

Namespace DN12;

Public Class XmlConverter
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        If rbCsvToXml.Checked Then
            ConvertCsvToXml()
        ElseIf rbXmlToCsv.Checked Then
            ConvertXmlToCsv()
        End If
    End Sub

    Private Sub ConvertCsvToXml()
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "CSV Files (*.csv)|*.csv"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim csvFile As String = openFileDialog.FileName
            Dim xmlFile As String = Path.ChangeExtension(csvFile, ".xml")

            Using writer As New XmlTextWriter(xmlFile, System.Text.Encoding.UTF8)
                writer.WriteStartDocument()
                writer.WriteStartElement("Root")

                Dim headers() As String
                Using reader As New StreamReader(csvFile)
                    If Not reader.EndOfStream Then
                        headers = reader.ReadLine().Split(","c)
                    End If

                    While Not reader.EndOfStream
                        Dim line As String = reader.ReadLine()
                        Dim values() As String = line.Split(","c)
                        writer.WriteStartElement("Record")
                        For i As Integer = 0 To headers.Length - 1
                            writer.WriteElementString(headers(i), values(i))
                        Next
                        writer.WriteEndElement()
                    End While
                End Using

                writer.WriteEndElement()
                writer.WriteEndDocument()
            End Using
            MessageBox.Show("CSV to XML conversion completed!")
        End If
    End Sub

    Private Sub ConvertXmlToCsv()
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "XML Files (*.xml)|*.xml"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim xmlFile As String = openFileDialog.FileName
            Dim csvFile As String = Path.ChangeExtension(xmlFile, ".csv")

            Using writer As New StreamWriter(csvFile)
                Using reader As XmlReader = XmlReader.Create(xmlFile)
                    While reader.Read()
                        If reader.IsStartElement() AndAlso reader.Name = "Record" Then
                            Dim record As String = ""
                            reader.ReadToDescendant("Field1")
                            Do
                                record &= reader.ReadElementContentAsString() & ","
                            Loop While reader.ReadToNextSibling("Field2")
                            writer.WriteLine(record.TrimEnd(","c))
                        End If
                    End While
                End Using
            End Using
            MessageBox.Show("XML to CSV conversion completed!")
        End If
    End Sub
End Class
