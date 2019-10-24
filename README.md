# Softpush
**Don't just block websites, add a nice message to remind you why you did.**

**Find yourself wasting too much time?** To easy to just "**peek**" and you end up falling down the rabbit hole... *again*?
Instead of outright blocking websites, which will lead to you using your phone or another device instead; you'll be greeted by a welcoming reminder screen instead of the Chrome Dinosaur game.
Complete with a good-looking background, clock and message reminding you why you blocked the site in the first place.

**Works deep in Windows.** It "blocks" websites using your Windows hosts file. You won't have access to these sites even if you end Softpush's service; you just won't have a nice screen reminding you why, you'll just have a standard "DNS error" page. **Using a VPN, Proxy or even an entirely new DNS won't allow your access back.**

The program runs in the background invisibly, starts with Windows and stays open. You can even turn on a 'Windows Service' to make sure the program stays open, even if you're tempted to close it.
The only time you'll remember it's there is when you try to access your blocked sites or when you change its settings.

## How does it work?
**Simple.**
Instead of blocking a website; you are instead redirected to a locally hosted "webpage", which is the afformentioned reminder screen.
The 'hosts' file within Windows tells your computer where to send TCP/IP traffic, ie Internet traffic.
Softpush adds "blocked" websites to this file and tells your computer to redirect you to a non-existant IP address, one that is redirected to Softpush running locally on your computer. [This is because web traffic is run on port 80, or 443 for HTTPS. You can't have more than one program listening to one port, and the Windows hosts file does not support custom ports.]

**tl;dr This is how it works:**
requestedsite<span></span>.com >> 127.0.4.20 [Non-existent IP address] >> 127.0.0.1:33312 [With hosted html. Can be different port]

-- Softpush, softly pushing you in better directions. Take back control.
