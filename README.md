# PersistentWebService
## a library to keep website alive
Website on IIS will go to die when no visitor for a long time,this library can keep website always alive no matter whatever visitor
### Configuration Web.config
#### Add handler to \<handlers> in <system.webServer>
```xml
<add name="DummyWatchdog" path="/handler/dummywatchdog" verb="*" type="PersistentWebService.DummyWatchdogHandler" />
```

#### Optionally,Add iisbindport to appSettings,which is the port number of your website on IIS
```xml
<add key="iisbindport" value="8081" />
```
