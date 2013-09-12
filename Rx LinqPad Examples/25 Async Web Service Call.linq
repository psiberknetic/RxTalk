<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <NuGetReference>Rx-Core</NuGetReference>
  <NuGetReference>Rx-Interfaces</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var request = HttpWebRequest.Create(new Uri("https://twitter.com/intent/user?screen_name=psiberknetic"));
	var twitterSearch = request.GetResponseAsync().ToObservable();
	//var twitterSearch = Observable.FromAsyncPattern<WebResponse>(request.BeginGetResponse, request.EndGetResponse);

	twitterSearch.Select(webResponse => WebResponseToString(webResponse))
	               .Subscribe(responseString => responseString.Dump());
				   
	"Request sent\n-----------\n".Dump();
}

// Define other methods and classes here
private string WebResponseToString(WebResponse webResponse)
{
  HttpWebResponse response = (HttpWebResponse)webResponse;
  using (StreamReader reader = new StreamReader(response.GetResponseStream()))
  {
    return reader.ReadToEnd();
  }
}