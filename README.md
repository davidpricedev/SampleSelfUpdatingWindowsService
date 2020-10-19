# SampleSelfUpdatingWindowsService
Testing a TopShelf service that can update itself. This is just a sample of what can be done. For a more powerful approach, take a look at [Google Omaha](https://omaha-consulting.com/auto-update-your-windows-service-with-google-omaha).

## To test:

1. Build one version. Copy the binaries to the run folder.
1. Build another version (different version number). Copy the binaries to the upgrade folder.
1. Install the service in the Run folder `SampleTopshelfSvc.exe install`
1. Start the service `net start SampleTopshelfSvc`
1. Wait a while and check the version number of the executable in the run folder, it should be the upgraded version.

## Other options for self-updating windows service

* Run two windows services - one that does the updating and the other that does the functionality you really want.
* Primary service is just a container that loads the real functionality as a plugin into a separate AppDomain. As long as you turn on shadow-copy when importing the real functionality, the functionality plugin should be able to update itself (to take effect next time the service starts or if the container is set to restart on file changes).
* PendingFileRenameOperations - tie into the same thing used by windows update, so next time the system restarts, windows will replace files for you.
* Have the service simply do `Process.Start` on any executable that stops the service, updates it, and starts it again.

It seems to me that the last option - to simply Process.Start an updater is vastly simpler than any of the other options. This doesn't come with any baggage code that can't be updated. It also doesn't require a reboot for things to take effect. The only slight downside is the need to have the updater know how to stop/start the service - not exactly a huge problem.
