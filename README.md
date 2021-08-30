# HTML Table Generator

HTML Table Generator is a WPF application that makes the process of writing HTML table code easier. It takes input from the user and generates the HTML table code accordingly.

## Backstory
I was working on an Ebook file that I intended to read on my kindle. The file had many Japanese dialogues and vocabularies that needed to be formatted into an HTML table so that the kindle can display it nicely.
I also had to make sure it supports furigana by using the ruby tag.

Coding this by hand was very tedious and close to impossible. So, I decided to make a tool that can automate the process. The HTML Table Generator is the result of that, along with another tool, the FuriganaTool.

## How to Use
<img src="DialougeToHtmlTable/Docs/DialogueFromGenki.png" width="700" alt="A dialogue From Genki"/>

Suppose the case, this dialogue, which is from the Japanese textbook Genki, needed to be formatted in an ebook file so that the kindle can read it nicely.
Formatting it into an HTML table would do the job and the code would be-
To do the same with this tool,
* First, input how many rows and columns it needs. In this case, It needs two columns and five rows, and also check on romaji support. Then click on Generate.

  <img src="DialougeToHtmlTable/Docs/AppInterface01.png" width="300" alt="AppInterface01"/>
  
* It will generate a new window containing text boxes corresponding to the number of rows and columns. Input the texts and then click Run.
  
  <img src="DialougeToHtmlTable/Docs/AppInterface02.png" width="700" alt="AppInterface02"/>
  
* It will generate another window with table code. You can copy the whole thing by clicking on Copy.

  <img src="DialougeToHtmlTable/Docs/AppInterface03.png" width="700" alt="AppInterface03"/>
