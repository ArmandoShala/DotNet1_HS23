.assembly Factorial {}
.assembly extern mscorlib {}

.method public static void Main() cil managed
{
    .entrypoint
        // lokale Variablen definieren
        .locals init (
            [0] int32 n,
    [1] int32 k
        )

    // Initialisierung der lokalen Variablen
    ldc.i4.5 // lade die Zahl 5 auf den Stack
    stloc.0 // speichere den Wert vom Stack in die lokale Variable n
    ldc.i4.1 // lade die Zahl 1 auf den Stack
    stloc.1 // speichere den Wert vom Stack in die lokale Variable k

    br.s CheckLoop // gehe zur Überprüfung der Schleife

    LoopStart: // Label für den Schleifenanfang
    ldloc.1 // lade den Wert von k auf den Stack
    ldloc.0 // lade den Wert von n auf den Stack
    mul // multipliziere die obersten zwei Werte auf dem Stack
        stloc.1 // speichere das Ergebnis in k
    ldloc.0 // lade den Wert von n auf den Stack
    ldc.i4.1 // lade die Zahl 1 auf den Stack
    sub // subtrahiere 1 von n
        stloc.0 // speichere das Ergebnis in n

    CheckLoop: // Label für die Überprüfung der Schleife
    ldloc.0 // lade den Wert von n auf den Stack
    ldc.i4.1 // lade die Zahl 1 auf den Stack
    bgt.s LoopStart // wenn n > 1, gehe zurück zum Schleifenanfang

    // Ausgabe des Ergebnisses
    ldloc.1 // lade den Wert von k auf den Stack
    call void [mscorlib]System.Console::WriteLine(int32) // rufe die WriteLine Methode auf

    // Beende das Programm
    ret
}