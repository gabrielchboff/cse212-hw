using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function shall add an item
    // (which contains both data and priority) to the back of the queue.
    // The Dequeue function shall remove the item with the highest
    // priority and return its value.
    // Expected Result: Test, 1 added to the Queue, removed, added test2, 3 and 4 and dequeue
    // the test4
    // Defect(s) Found: The Dequeue does not remove the item from the list.
    // The second problem is that the loop that finds the highest priority item isn't
    // checking all elements in the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Test", 1);
        var item = priorityQueue.Dequeue();
        //Console.WriteLine(priorityQueue);
        priorityQueue.Enqueue("Test2", 2);
        priorityQueue.Enqueue("Test3", 3);
        priorityQueue.Enqueue("Test4", 4);
        //Console.WriteLine(priorityQueue);
        var item2 = priorityQueue.Dequeue();
        Assert.AreEqual("Test", item);
        Assert.AreEqual("Test4", item2);
        //Console.WriteLine(item2);
        //Console.WriteLine(priorityQueue);
        
    }

    [TestMethod]
    // Scenario: Testing priority levels dequeue
    // Expected Result: Assert 4 levels and add more as describe in the step by step bellow
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
    
        // Add items with different priorities
        priorityQueue.Enqueue("Test", 1);    // Lowest priority
        priorityQueue.Enqueue("Test2", 2);
        priorityQueue.Enqueue("Test3", 3);
        priorityQueue.Enqueue("Test4", 4);   // Current highest priority
    
        // Dequeue should return highest priority item ("Test4")
        var item = priorityQueue.Dequeue();
    
        // Add new items with higher priorities
        priorityQueue.Enqueue("Test5", 5);   // New highest priority
        priorityQueue.Enqueue("Test6", 6);   // New highest priority
    
        // Dequeue should return items in order of priority
        var item2 = priorityQueue.Dequeue(); // "Test6" (priority 6)
        var item3 = priorityQueue.Dequeue(); // "Test5" (priority 5)
        var item4 = priorityQueue.Dequeue(); // "Test3" (priority 3)
        var item5 = priorityQueue.Dequeue(); // "Test2" (priority 2)
        var item6 = priorityQueue.Dequeue(); // "Test"  (priority 1)
    
        // Assert the correct order based on priority
        Assert.AreEqual("Test4", item);   // First dequeue gets priority 4
        Assert.AreEqual("Test6", item2);  // Then priority 6
        Assert.AreEqual("Test5", item3);  // Then priority 5
        Assert.AreEqual("Test3", item4);  // Then priority 3
        Assert.AreEqual("Test2", item5);  // Then priority 2
        Assert.AreEqual("Test", item6);   // Finally priority 1
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Testing dequeue in a empty list
    // Expected Result: Throws an exception defined in the method
    // Defect(s) Found: None
    public void Dequeue_EmptyQueue_ThrowsException()
    {
        var queue = new PriorityQueue();
        
        var exception = Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}