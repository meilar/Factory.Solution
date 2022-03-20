<h1 align="center">RepairWare</h1>

Matthew Eilar | [LinkedIn](https://www.linkedin.com/in/eilar-503/) | [email](mailto:<meilar@gmail.com>) | [website](https://www.mattheweilar.com)

![Screenshot of webapp](/project_screenshot.jpg)
## About this project
*RepairWare* is a .Net 5 web application adhering to the MVC (Model-View-Controller) design pattern. This project was created as an [Epicodus](https://www.epicodus.com) weekly independent project. 

This application allows a factory owner to track a list of technicians, a list of machines, and to associate those technicians with the machines that they are qualified to service. 

## Technologies Used

This site incorporates the following frameworks and languages:

- C#
- HTML
- CSS
- Bootstrap 4
- .NET Core + Entity Core
- Git
- MySQL & MySQL Workbench

## Accessing this application

### Pre-installation

Before downloading project files, you must have the following tools installed:

- You should know to open a command line on your operating system. [Here's a beginner's guide if you don't know what that means.](https://www.learnenough.com/command-line-tutorial)
- Git | [Instructions](https://github.com/git-guides/install-git)
- .NET | [Instructions](https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/intro)
- MySQL Community Server & MySQL Workbench | [Instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql)   

### Downloading the application

- Open your command line and clone this project with the following instruction: `$ git clone https://www.github.com/meilar/Factory.Solution`
- Open the project folder in a file browser. Navigate to the `Factory` folder.
- Create a new file named `appsettings.json`, and insert this block of code. Make sure to enter the userid and password you set up when installing MySQL Community Server in the brackets:
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=matthew_eilar;uid={YOUR USER ID HERE};pwd={YOUR PASSWORD HERE};"
  }
}
```

### Starting the application

- Navigate to the project folder in your Terminal with the following command: `cd Factory.Solution/Factory`
- Install project dependencies with the command `dotnet restore`
- Confirm that the project builds successfully with the command `dotnet build`
- Start the database with the command `dotnet ef dabase update`
- Start the application with the following command: `dotnet run`
- Open the displayed URL in a web browser, typically `http://localhost:5000`. Please note that this project was designed and tested in Google Chrome, and all features may not be supported in all browsers.

## Further Exploration

- Application currently allows you to add duplicate machine licenses to engineers, I would need to add some validation logic to prevent this from happening.
- 

## Acknowledgements

Thank you to my partner, Alex, for support in all ways. Thank you to my parents for encouraging technology exploration, even when resources were scarce. Thank you to the Kohlenberg Foundation for sending the light bulbs.

## License 

MIT License

© 2022 Matthew Eilar

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
