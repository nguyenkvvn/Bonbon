
<img src="https://i.imgur.com/rD1HD2t.png" alt="Bonbon Icon" width="40" height="40" /> Bonbon
===================
> tôi đi ăn cái món ngon

> dám bạn muốn nếm thử

Bonbon is a simple display manager using NirSoft's MultiMonitorTool that enables and disables monitors before and after a user uses Windows Mixed Reality respectively.

----------
Getting Started
-------------
 1. Download and extract Bonbon to somewhere permanent and convenient.
 2. Download NirSoft's MultiMonitorTool from [here](http://www.nirsoft.net/utils/multi_monitor_tool.html).
 3. Extract the entirety of NirSoft's tool into a folder named "MultiMonitorTool". The folder you just created should be in the same directory as your Bonbon.exe file.
 4. Run Bonbon.

----------
What does it do?
-------------
If you are using a multi-display setup at your work/battle-station along with a VR headset (specifically a Windows Mixed Reality one), you may discover that using your desktop in the virtual reality space is difficult due to the sheer size, or that your VR headset may not display anything until you disable a monitor. Bonbon detects when you start or stop Windows MR, and will disable/enable your preferred displays accordingly. 

-------
FAQ
-------------
*Q:* Why does Bonbon need to be "Run as an administrator"?
*A:* The ManagementEventWatcher class needs Administrator permissions to be able to inspect your process tree and let Bonbon know when you started or stopped the Windows MR application. Bonbon (and other applications) would be denied access to viewing your list of open apps under normal conditions for security reasons.

*Q:* I have a GPU that supports more than four displays! Is Bonbon for me?
*A:* **NO.** Bonbon is intended only for computers with consumer GPUs that can only support, at most, four monitors. Chances are, if your GPU has support for more than four or five, it can handle a 6th (your MR headset!).

*Q:* Are you affiliated or endorsed by NirSoft in any way?
*A:* I am not. 

*Q:* Of all names, why did you choose "Bonbon"?
*A:* I was listening to Era Istrefi's "Bonbon" (not affiliated or endorsed in any way) and I got the song stuck in my head. 

*Q:* Is the quote above a Vietnamese translation of-?
*A:* haha yes. 

----------
License
-------------
>MIT License
>
> Copyright (c) 2017 Vinh Nguyen

> Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

> The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
