# SampleSelfUpdatingWindowsService
Testing a TopShelf service that can update itself

## To test:

1. Build one version. Copy the binaries to the run folder.
1. Build another version (different version number). Copy the binaries to the upgrade folder.
1. Install the service in the Run folder `SampleTopshelfSvc.exe install`
1. Start the service `net start SampleTopshelfSvc`
1. Wait a while and check the version number of the executable in the run folder, it should be the upgraded version.

## Note

Obviously this code is a sample of what can be done and is in no way ready for any production environment.
