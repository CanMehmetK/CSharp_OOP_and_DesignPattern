﻿

##### 2015 11 24 - kanpinar

## Design Patterns: Elements of Reusable Object-Oriented Software  
## Page : 99 - Abstract Factory

Intent <br/>
    Provide an interface for creating families of related or dependent objects without specifying their concrete classes.<br/>

Niyet<br/>
    Somut classları belirtmeden ilişkili veya bağımlı objeleri ailesini oluşturmak için bir interface sağlamak.<br/>

Motivation<br/>
    Consider a user interface toolkit that supports multiple look-and-feel standards,such as Motif and Presentation Manager. <br/>
Different look-and-feels define different appearances and behaviors for user interface "widgets" like scroll bars, windows,and buttons. <br/>
To be portable across look-and-feel** standards, an application should not hard-code its widgets for a particular look and feel. <br/>
Instantiating look-and-feel-specific classes of widgets throughout the application makes it hard to change the look and feel later.<br/>
<br/>
We can solve this problem by defining an abstract WidgetFactory class that declares an interface for creating each basic kind of widget.<br/>
There's also an abstract class for each kind of widget, and concrete subclasses implement widgets for specific look-and-feel standards.<br/>
WidgetFactory's interface has an operation that returns a new widget object for each abstract widget class. <br/>
Clients call these operations to obtain widget instances, but clients aren't aware of the concrete classes they're using. <br/>
Thus clients stay independent of the prevailing look and feel.   <br/>

   Birden fazla kullanım ve görünüm destekleyen bir kullanıcı arayüzünü göz önünde bulundurun, Motif ve Presentation Manager gibi.<br/>
Farklı görünüm ve kullanım şunu ifade eder; farklı görsellik ve çalışma şekli kullanıcı arayüzü "widgets" için kaydırma çubuğu pencere ve düğmeler gibi.<br/>
Tema standardının taşınabilirliği için uygulama kod içerisinde belirli bir tema için widget ları içermemelidir.<br/>
<br/>
<br/>
** : Kelimelerin bazılarının tam karşılığını bulamıyorum. O yüzden ingilizcelerini ile yazıyorum.<br/>

