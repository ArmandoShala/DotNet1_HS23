using System;
using System.Diagnostics;

public class ButtonUsageCounter : IDisposable
{
    public const string CategoryName = "Button Usage";
    public PerformanceCounter UpdateClicks;
    public PerformanceCounter RegisterClicks;

    public ButtonUsageCounter()
    {
        if (!PerformanceCounterCategory.Exists(CategoryName))
        {
            var counters = new CounterCreationDataCollection();

            counters.Add(new CounterCreationData
            {
                CounterName = "UpdateClick",
                CounterType = PerformanceCounterType.NumberOfItems32
            });

            counters.Add(new CounterCreationData
            {
                CounterName = "RegisterClick",
                CounterType = PerformanceCounterType.NumberOfItems32
            });

            PerformanceCounterCategory.Create(CategoryName, "Button usage counters", PerformanceCounterCategoryType.SingleInstance, counters);
        }

        // Initialize the performance counters without setting the RawValue property
        UpdateClicks = new PerformanceCounter(CategoryName, "UpdateClick", false);
        RegisterClicks = new PerformanceCounter(CategoryName, "RegisterClick", false);
    }

    public void IncrementUpdateClicks()
    {
        UpdateClicks.Increment();
    }

    public void IncrementRegisterClicks()
    {
        RegisterClicks.Increment();
    }

    public void DecrementRegisterClicks()
    {
        RegisterClicks.Decrement();
    }

    public void Dispose()
    {
        UpdateClicks?.Dispose();
        RegisterClicks?.Dispose();

        if (PerformanceCounterCategory.Exists(CategoryName))
        {
            PerformanceCounterCategory.Delete(CategoryName);
        }
    }
}