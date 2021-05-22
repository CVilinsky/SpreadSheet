using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW3
{
	class Semaphore
	{
		Mutex m_resource;
		Mutex m_wait;
		int resource;
		int max_users;
		bool Flag;
		public Semaphore(int n)
		{
			this.max_users = n;
			this.resource = n;
			this.Flag = false;
			this.m_resource = new Mutex();  // mutex to manage change in resource 
			this.m_wait = new Mutex();  // mutex that will work if we are out of resources	
		}
		public void Wait()
		{
			this.m_wait.WaitOne();
			this.resource--;
			this.m_resource.ReleaseMutex();
			if(this.resource < 0)
			this.Flag = true;
			while(Flag){ }; // wait until able to enter		
			this.m_wait.ReleaseMutex();
		}
		public  void signal()
		{
			this.m_resource.WaitOne();
			if (this.resource < this.max_users)
				this.resource++;
			this.m_resource.ReleaseMutex();
			this.Flag = false;
			
		}
	}
}
