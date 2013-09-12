<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <NuGetReference>Rx-Core</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

void Main()
{
	var watchMe = new FileSystemWatcher(@"C:\WatchMe", "*.*"){EnableRaisingEvents=true};
	
	
	var sources = new[] 
                { 
                    Observable.FromEventPattern<FileSystemEventArgs>(watchMe, "Created"),
 
                    Observable.FromEventPattern<FileSystemEventArgs>(watchMe, "Changed"),
 
                    Observable.FromEventPattern<FileSystemEventArgs>(watchMe, "Renamed"),
 
                    Observable.FromEventPattern<FileSystemEventArgs>(watchMe, "Deleted")
                };
	
	var directoryChanges = sources.Merge()
			.Select(evt => new {Time=DateTime.Now, evt.EventArgs})
			.Buffer(TimeSpan.FromSeconds(10))
			.Finally(()=> watchMe.Dispose());
	
	directoryChanges.Subscribe(x=> 
				{
					var changes = x.Select(y=>string.Format("{0} was {1} at {2}", y.EventArgs.Name, y.EventArgs.ChangeType, y.Time));
					foreach(var change in changes){
						change.Dump();
					}
				});
	
	while(true){}
}

