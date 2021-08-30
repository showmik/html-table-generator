# HTML Table Generator

**HTML Table Generator** is a WPF application that makes the process of writing HTML table code easier. It takes input from the user and generates HTML table code accordingly.

## Backstory
I was working on an ebook file that I intended to read on my kindle. The file had many Japanese dialogues and vocabularies that needed to be formatted into an HTML table so that the kindle can display it nicely.
I also had to make sure it supports furigana by using [HTML ruby syntax](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/ruby) tag.

Coding this by hand was very tedious and close to impossible. So, I decided to make a tool that can automate this process. The HTML Table Generator is the result of that, along with another tool, the **FuriganaTool**.

## How to Use
<img src="DialougeToHtmlTable/Docs/DialogueFromGenki.png" width="550" alt="A dialogue From Genki"/>

Suppose the case, this dialogue, which is from the Japanese textbook *[Genki](https://en.wikipedia.org/wiki/Genki:_An_Integrated_Course_in_Elementary_Japanese)*, needed to be incorporated in an ebook file such a way that the kindle can read it nicely.

Formatting it into an HTML table would do the job. The code (excluding furigana) would be:
```
<table>
    <tr>
       <td>だけし:<br/>Takeshi</td>
       <td>こんにちは。きむら たけしです。<br/>Konnichiwa. Kimura Takeshi desu.</td>
    </tr>
    <tr>
       <td>メアリー:<br/>Mearii</td>
       <td>メアりー・ハートです。あのう、りゅうがくせいですか。<br/>Mearii Haato desu. Anoo, ryuugakusee desu ka.</td>
    </tr>
    <tr>
       <td>だけし:<br/>Takeshi</td>
       <td>いいえ、にほんじんです。<br/>iie, nihonjin desu.</td>
    </tr>
    <tr>
       <td>メアリー:<br/>Mearii</td>
       <td>そうですか。なんねんせいですか。<br/>Soo desu ka. Nannensee desu ka.</td>
    </tr>
    <tr>
       <td>だけし:<br/>Takeshi</td>
       <td>よねんせいです。<br/>Yonensee desu.</td>
    </tr>
</table>

```


### To do the same with this **HTML Table Generator**:
* First, input how many rows and columns it needs. In this case, It needs two columns and five rows, and also check on romaji support. Then click on Generate.

  <img src="DialougeToHtmlTable/Docs/AppInterface01.png" width="280" alt="AppInterface01"/>
  
* It will generate a new window containing text boxes corresponding to the number of rows and columns. Input the texts and then click Run.
  
  <img src="DialougeToHtmlTable/Docs/AppInterface02.png" width="550" alt="AppInterface02"/>
  
* It will generate another window with table code. You can copy the whole thing by clicking on Copy.

  <img src="DialougeToHtmlTable/Docs/AppInterface03.png" width="550" alt="AppInterface03"/>
  
After adding styling, it can look good on kindle.

<img src="DialougeToHtmlTable/Docs/Kindle.jpg" width="550" alt="AppInterface03"/>
