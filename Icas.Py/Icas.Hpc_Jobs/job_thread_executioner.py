from threading import Thread

class ThreadExecutioner(object):
    """description of class"""

    threads = []
    thread_limit = 10

    def __init__(self, thread_limit):
        self.thread_limit = thread_limit

    def add(self, thread):
        """add a thread to the pool, run and empty the pool when it meets the limit of threads"""
        if(len(self.threads)==self.thread_limit):
            self.run_all()
        self.threads.append(thread)

        
    def run_all(self):
        """run and empty the pool when it meets the limit of threads"""
        for thread in self.threads:
            thread.start()
        for thread in self.threads:
            thread.join()
        self.threads = []



