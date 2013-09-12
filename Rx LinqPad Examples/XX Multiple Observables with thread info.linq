<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>C:\tfsprod\Sherman\Main\Assemblies\AutoMapper.dll</Reference>
  <Reference Relative="..\..\AutoMapperTraining\AutoMapperTraining\bin\AutoMapperTraining.dll">C:\Users\Nate\Dropbox\AutoMapperTraining\AutoMapperTraining\bin\AutoMapperTraining.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Formatters.Soap.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <NuGetReference>Rx-Core</NuGetReference>
  <NuGetReference>Rx-Interfaces</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <NuGetReference>Rx-WPF</NuGetReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

var oneSecond = Observable.Interval(TimeSpan.FromSeconds(1)).Take(5);
var halfSecond = Observable.Interval(TimeSpan.FromSeconds(0.5)).Take(5);

oneSecond.ObserveOn(Scheduler.Default).Subscribe(
						x=>string.Format("Thread " + Thread.CurrentThread.ManagedThreadId + ": " + x).Dump("1 second"),
						ex=>ex.Dump(),
						()=>"1 second finished".Dump()
					);
halfSecond.ObserveOn(Scheduler.Default).Subscribe(
						x=>string.Format("Thread " + Thread.CurrentThread.ManagedThreadId + ": " + x).Dump("0.5 second"),
						ex=>ex.Dump(),
						()=>"0.5 second finshed".Dump()
					);
					