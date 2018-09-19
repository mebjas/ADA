namespace Algorithms
{
    using System;
    using System.Threading;

    /// <summary>
    /// Semaphore Class with variable concurrency
    /// </summary>
    public class SemaphoreFat : IDisposable
    {
        /// <summary>
        /// Maximum capacity of this semaphore
        /// </summary>
        private int maxCapacity;

        /// <summary>
        /// Current capacity of this semaphore
        /// </summary>
        private int capacity;

        /// <summary>
        /// Count of reserved handles
        /// </summary>
        private int reservedCount = 0;

        /// <summary>
        /// internal semaphore object instance
        /// </summary>
        private SemaphoreSlim sem;

        /// <summary>
        /// Initializes a new instance of the <see cref="SemaphoreFat" /> class.
        /// </summary>
        /// <param name="initialCapacity">initial capacity</param>
        /// <param name="maxCapacity">max allowed capacity</param>
        public SemaphoreFat(int initialCapacity, int maxCapacity)
        {
            if (this.capacity > maxCapacity)
            {
                throw new InvalidOperationException("Capacity cannot be greater than Max");
            }

            this.maxCapacity = maxCapacity;
            this.capacity = initialCapacity;
            this.sem = new SemaphoreSlim(this.maxCapacity);
            this.UpdateHeldCapacity(this.capacity, this.maxCapacity);
        }

        /// <summary>
        /// Gets count of reserved handles
        /// </summary>
        public int ReservedCount
        {
            get
            {
                return this.reservedCount;
            }
        }

        /// <summary>
        /// Blocks the current thread until it can enter the <see cref="SemaphoreFat"/>
        /// </summary>
        public void Wait()
        {
            this.sem.Wait();
            this.reservedCount++;
        }

        /// <summary>
        /// Releases the <see cref="SemaphoreFat"/> object once.
        /// </summary>
        public void Release()
        {
            this.sem.Release();
            this.reservedCount--;
        }

        /// <summary>
        /// Updates the capacity of the semaphore. If it's a capacity increase request
        /// This thread shall be blocked until that happens
        /// </summary>
        /// <param name="newCapacity">new capacity of the semaphore</param>
        public void Update(int newCapacity)
        {
            if (newCapacity <= 0)
            {
                throw new InvalidOperationException("Capacity cannot be less than or equal to zero;");
            }

            if (newCapacity > this.maxCapacity)
            {
                throw new InvalidOperationException("Capacity cannot be greater than or max capacity;");
            }

            this.UpdateHeldCapacity(newCapacity, this.capacity);
            this.capacity = newCapacity;
        }

        /// <summary>
        /// Disposes the object
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.sem.Dispose();
            }
            catch
            {
                ////
            }
        }

        /// <summary>
        /// Method to update the capacity of this semaphore
        /// </summary>
        /// <param name="newCapacity">new capacity requested</param>
        /// <param name="oldCapacity">older capacity</param>
        private void UpdateHeldCapacity(int newCapacity, int oldCapacity)
        {
            int delta = newCapacity - oldCapacity;
            if (delta < 0)
            {
                for (int i = 0; i < -delta; i++)
                {
                    this.sem.Wait();
                }
            }
            else
            {
                for (int i = 0; i < delta; i++)
                {
                    this.sem.Release();
                }
            }
        }
    }
}
