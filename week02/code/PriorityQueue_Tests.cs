using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function shall add an item (which contains both data and 
    // priority) to the back of the queue.
    // Expected Result: priorityQueue.Items[0].Value = "Joseph"
    //                  priorityQueue.Items[1].Value = "Purity"
    //                  priorityQueue.Items[0].Priority = 1
    //                  priorityQueue.Items[1].Priority = 2
    // Scenario: The Dequeue function shall remove the item with the highest priority and return 
    // its value.
    // Expected Result: result = "Purity (Pri:2)"
    //                  priorityQueue.Items[0].Value = "Joseph"
    //                  priorityQueue.Items.Count = 1

    // Scenario: If there are more than one item with the highest priority, then the item closest
    // to the front of the queue will be removed and its value returned.
    // Expected Result: result = "Purity (Pri:2)"
    //                  priorityQueue.Items.Count = 2

    // Defect(s) Found: There are no defects in the Enqueue function, but I did have to give myself 
    //access to the _queue variable for testing.  
    // 1) PriorityQueue => internal IReadOnlyList<PriorityItem> Items => _queue; 
    //Dequeue Function: 
    // 1) The loop in the dequeue function had the index start at 1, changed to 0.
    //2) The until operator in the for loop needs to be <=.  Added =.
    //3) Changed to if(_queue[index].Priority >= higPriorityIndex)-- highPriorityIndex has 
    //   no .Priority value and is not located in _value. 
    //4) Function only found the value at the index equal to the highest priority which is
    //   not the value we need.  We need the first object whose priority matches the value
    //   of the highest priority value identified.  Added logic to find this value. 
    //5) Function did not remove value from the queue. Added logic to remove from queue.
    // No Defects found in repeating priorities test. 
    
    public void TestPriorityQueue_1()
    {
     //Enqueue Function   
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Joseph", 1);
        priorityQueue.Enqueue("Purity", 2);

        bool valid = true;
     
     
        Assert.AreEqual(priorityQueue.Items[0].Value, "Joseph");
        Assert.AreEqual(priorityQueue.Items[1].Value,  "Purity");
        Assert.AreEqual(priorityQueue.Items[0].Priority, 1);
        Assert.AreEqual(priorityQueue.Items[1].Priority, 2);

        //Dequeue Function  
        var result = priorityQueue.Dequeue();
        Assert.AreEqual(result, "Purity") ;

        Assert.AreEqual(priorityQueue.Items[0].Value, "Joseph");
        Assert.AreEqual(priorityQueue.Items.Count, 1);

        //Matching Priorities

        priorityQueue.Enqueue("Purity", 2);
        priorityQueue.Enqueue("Serenity", 2);
        result = priorityQueue.Dequeue();
        Assert.AreEqual(result, "Purity"); 
        Assert.AreEqual(priorityQueue.Items.Count, 2);


    }

    [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be thrown. This exception 
    // should be an InvalidOperationException with a message of "The queue is empty."
    // Expected Result:<InvalidOperationException> "The queue is empty"
    // Defect(s) Found: None

    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
        priorityQueue.Dequeue()  
        ); 
        Assert.AreEqual("The queue is empty.", ex.Message) ; 

    }

    // Add more test cases as needed below.
}