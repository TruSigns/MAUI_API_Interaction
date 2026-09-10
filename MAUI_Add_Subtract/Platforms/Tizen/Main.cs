using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MAUI_Add_Subtract;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
