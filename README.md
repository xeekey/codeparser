<a name="readme-top"></a>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![Linkedin][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <!--<a href="https://github.com/xeekey/codeparser">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a> -->

<h3 align="center">CodeParser</h3>

  <p align="center">
    A tool for parsing C# and VB.NET projects, extracting structured information into JSON format.
    <br />
    <a href="https://github.com/xeekey/codeparser"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/xeekey/codeparser">View Demo</a>
    ·
    <a href="https://github.com/xeekey/codeparser/issues">Report Bug</a>
    ·
    <a href="https://github.com/xeekey/codeparser/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

CodeParser is a tool designed for parsing C# and VB.NET projects. It analyzes source code files and extracts structured information about classes, methods, properties, and more, saving the output in JSON format.

Components:
1. **C# Parser (`csharpparser`):** Parses `.cs` files and extracts details about classes, methods, and properties.
2. **VB.NET Parser (`vbparser`):** Parses `.aspx` and `.vb` files, extracting information about ASPX pages and code-behind classes.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

* [![C#][C#-shield]][C#-url]
* [![C#][VB.NET-shield]][VB-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage

Set the `projectDirectory` variable in the respective parser (C# or VB.NET) to the path of your project. Run the parser to generate a JSON file with structured data about your source code.

_For more examples, please refer to the [Documentation](https://github.com/xeekey/codeparser)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->
## Contributing

Contributions to CodeParser are welcome. Please follow the standard GitHub pull request process to submit your changes.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->
## Contact
Project Link: [https://github.com/xeekey/codeparser](https://github.com/xeekey/codeparser)

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/xeekey/codeparser.svg?style=for-the-badge
[contributors-url]: https://github.com/xeekey/codeparser/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/xeekey/codeparser.svg?style=for-the-badge
[forks-url]: https://github.com/xeekey/codeparser/network/members
[stars-shield]: https://img.shields.io/github/stars/xeekey/codeparser.svg?style=for-the-badge
[stars-url]: https://github.com/xeekey/codeparser/stargazers
[issues-shield]: https://img.shields.io/github/issues/xeekey/codeparser.svg?style=for-the-badge
[issues-url]: https://github.com/xeekey/codeparser/issues
[license-shield]: https://img.shields.io/github/license/xeekey/codeparser.svg?style=for-the-badge
[license-url]: https://github.com/xeekey/codeparser/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/linkedin_username
[product-screenshot]: images/screenshot.png
[C#-shield]: https://img.shields.io/badge/C%23-239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white
[C#-url]: https://docs.microsoft.com/en-us/dotnet/csharp/
[VB.NET-shield]: https://img.shields.io/badge/VB.NET-512BD4.svg?style=for-the-badge&logo=visual-studio&logoColor=white
[VB-url]: https://docs.microsoft.com/en-us/dotnet/visual-basic/
[linkedin-url]: https://linkedin.com/in/kasper-hjort-jæger
