/*
 * Created by SharpDevelop.
 * User: Karl Rege
 * Date: 03.08.2023
 * Time: 15:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Diagnostics;

namespace DN8 {
    
    public class ButtonUsageCounter: IDisposable  {
        public const string CategoryName = "Button Usage";
        public PerformanceCounter RegisterClicks;
        public PerformanceCounter UpdateClicks;

        public ButtonUsageCounter() {
            var UpdateButtonClick = new CounterCreationData();
            UpdateButtonClick.CounterName = "UpdateClick";
            UpdateButtonClick.CounterType = PerformanceCounterType.NumberOfItems32;
            UpdateButtonClick.CounterHelp = "Counts the number of times the update button is clicked.";

            // Creation data for RegisterClick - This part was missing and is now completed
            var RegButtonClick = new CounterCreationData();
            RegButtonClick.CounterName = "RegisterClick";
            RegButtonClick.CounterType = PerformanceCounterType.NumberOfItems32;
            RegButtonClick.CounterHelp = "Counts the number of times the register button is clicked.";
   
            // Create Collection of CreationData 
            var ClickCounters = new CounterCreationDataCollection();
            ClickCounters.Add(RegButtonClick);
            ClickCounters.Add(UpdateButtonClick);

            // Create new Performance counter Category
            PerformanceCounterCategory.Create(ButtonUsageCounter.CategoryName, "Various click counters on the form, used to weigh each button on this form",
                PerformanceCounterCategoryType.SingleInstance, ClickCounters);

            // Now create actual measuring counters
            RegisterClicks = new PerformanceCounter(CategoryName, "RegisterClick", false);
            UpdateClicks = new PerformanceCounter(CategoryName, "UpdateClick", false);
        }
        public void Dispose() {
            if (PerformanceCounterCategory.Exists(CategoryName)) {
                PerformanceCounterCategory.Delete(CategoryName);
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            using var counter = new ButtonUsageCounter();
            
            // Increment the UpdateClicks counter by 1
            //counter.UpdateClicks.Increment();

            // Increment the RegisterClicks counter by 1
            //counter.RegisterClicks.Increment();

            // If you had a way to detect a 'Leave' action, you would decrement the counter as well.
            // For example, if a 'Leave' button is clicked:
            // counter.RegisterClicks.IncrementBy(-1);


        }
    }

}
