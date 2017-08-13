
<p align="center">
  <img src="http://github.messatsu-dojo.com/previews/satsuilocalization.gif" alt="SatsuiUi preview"/>
</p>

# What is SatsuiLocalization ? #

SatsuiLocalization is a library containing a translation system i created for my own WPF projects.  
You can change the language on the fly.  
It's easy, fast to use and free.

# How to install it ? #

The Nuget package is available here : [https://www.nuget.org/packages/Messatsu.SatsuiLocalization/](https://www.nuget.org/packages/Messatsu.SatsuiLocalization/ "Messatsu.SatsuiLocalization")

    PM> Install-Package Messatsu.SatsuiLocalization

# How to use it ? #

When the Nuget package is installed, instantiate a Translation object then load a XML file or an embed resource containing the language definition :

    Translation myLang = new Translation();
	myLang.LoadFile("path-to-the-xml-file.xml");
	// Or myLang.LoadResource("MyProject.Folder.XmlFile.xml");
	// Don't forget to set your resource as an embed resource !

You can also use statics functions of the Translation class :

	Translation myLang = Translation.FromFile("path-to-the-xml-file.xml");
	Translation myLang = Translation.FromResource("MyProject.Folder.XmlFile.xml");

Example of a basic language definition file :

	<?xml version="1.0" encoding="utf-8" ?>
	<lang name="English" author="SatsuiBird">
		<general>
    		<copy>Copy</copy>
    		<paste>Paste</paste>
			<exit>Exit</exit>
		</general>
		<main-window>
			<tb-test>Im a text $ln with a newline !</tb-text>
			<btn-test>Im a test button</btn-test>
		</main-window>
		<messages>
			<test-parameter>Your parameter is : $p</test-parameter>
			<test-variable>My variable is : $myvar</test-variable>
		</messages>
	</lang>


Now the language is loaded, you just have to call the **Translate** function, giving it the control to translate and a XML root element :

	// Called from the code-behind of MainWindow.xaml
	myLang.Translate(this, "main-window");

So, in the XMAL definition of MainWindow, i just have to set properties as **id:***<xml-node>*

	<TextBlock Text="id:tb-test"/>
	<Button Content="id:btn-test"/>

Here, **tb-test** and **btn-test** are found because we passed **main-window** as the root element.  
But you can access parents elements if you use a **slash** before the node name :

	<TextBlock Text="id:/general/copy"/>

# How to access it in the code-behind ? #

You can access it with the function **GetString** givint it the path and an optional parameter :

	string result = myLang.GetString("messages/test-parameter", "my parameter");

In the language file, the node **test-parameter** is defined as "Your parameter is : $p".  
So, SatsuiLocalization will replace **$p** by the parameter passed to GetString and will return "Your parameter is : my parameter".

# Add your own variables #

As we have seen, SatsuiLocalization use **$p** and **$ln** variables, but you can add your own variables.  
It's useful when you need to show informations which are not language related, like application name, version, ...  
You can do it with the static function AddVar of the Translation class.

	Translation.AddVar("myvar", "hello world");

In the language file, the node **test-variable** is defined as "My variable is : $myvar" :

	// Will return : My variable is : hello world
	string reuslt = myLang.GetString("messages/test-variable");
	
# Eh, it's not translating my own controls ! #

If you created your own control with custom properties which are not managed by SatsuiLocalization, you can use the function AddCustomControl. There is an example in **DemoWPF**.

	myLang.AddCustomControl(typeof(YourControlClass), "CustomProperty1", "CustomProperty2", ...);


# My others projects #

**SatsuiUi**  
Set of controls and skins for WPF applications  
[https://github.com/SatsuiBird/SatsuiUiDemo](https://github.com/SatsuiBird/SatsuiUiDemo "SatsuiUiDemo")

**SatsuiMemory**  
Read and edit applications memory easily  
[https://github.com/SatsuiBird/SatsuiMemoryDemo](https://github.com/SatsuiBird/SatsuiMemoryDemo "SatsuiMemoryDemo")

**SatsuiOverlay**  
Create customizable HTTP widgets  
[https://github.com/SatsuiBird/SatsuiOverlayDemo](https://github.com/SatsuiBird/SatsuiOverlayDemo "SatsuiOverlayDemo")
