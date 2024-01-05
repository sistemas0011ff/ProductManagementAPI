á	
sD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\commands\CreateProductCommand.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
commands3 ;
{ 
public 

class  
CreateProductCommand %
:& '
IRequest( 0
<0 1)
ProductResponseApplicationDto1 N
>N O
{ 
public (
ProductRequestApplicationDto +
Product, 3
{4 5
get6 9
;9 :
private; B
setC F
;F G
}H I
public		  
CreateProductCommand		 #
(		# $(
ProductRequestApplicationDto		$ @
product		A H
)		H I
{

 	
Product 
= 
product 
??  
throw! &
new' *!
ArgumentNullException+ @
(@ A
nameofA G
(G H
productH O
)O P
)P Q
;Q R
} 	
} 
} ö)
zD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\commands\CreateProductCommandHandler.cs
	namespace		 	 
ProductManagementAPI		
 
.		 
Product		 &
.		& '
Application		' 2
.		2 3
commands		3 ;
{

 
public 

class '
CreateProductCommandHandler ,
:- .
IRequestHandler/ >
<> ? 
CreateProductCommand? S
,S T)
ProductResponseApplicationDtoU r
>r s
{ 
private 
readonly 
IProductRepository +
_productRepository, >
;> ?
private 
readonly 
IEventStore $
_eventStore% 0
;0 1
private 
readonly 
IProductFactory (
_productFactory) 8
;8 9
public '
CreateProductCommandHandler *
(* +
IProductRepository, >
productRepository? P
,P Q
IEventStoreS ^

eventStore_ i
,i j
IProductFactoryk z
productFactory	{ â
)
â ä
{ 	
_productRepository 
=  
productRepository! 2
;2 3
_eventStore 
= 

eventStore $
;$ %
_productFactory 
= 
productFactory ,
;, -
} 	
public 
async 
Task 
< )
ProductResponseApplicationDto 7
>7 8
Handle9 ?
(? @ 
CreateProductCommand@ T
requestU \
,\ ]
CancellationToken^ o
cancellationToken	p Å
)
Å Ç
{ 	
try 
{ 
var 
	estadoPrd 
= 
new  #
ProductStatus$ 1
(1 2
request2 9
.9 :
Product: A
.A B
StatusB H
)H I
;I J
var 
productCreationDto &
=' (
new) ,
ProductCreationDto- ?
{ 
Name   
=   
request   "
.  " #
Product  # *
.  * +
Name  + /
,  / 0
Price!! 
=!! 
request!! #
.!!# $
Product!!$ +
.!!+ ,
Price!!, 1
,!!1 2
Stock"" 
="" 
request"" #
.""# $
Product""$ +
.""+ ,
Stock"", 1
,""1 2
Description## 
=##  !
request##" )
.##) *
Product##* 1
.##1 2
Description##2 =
,##= >
Status$$ 
=$$ 
	estadoPrd$$ &
.$$& '
Value$$' ,
}%% 
;%% 
var&& 

newProduct&& 
=&&  
_productFactory&&! 0
.&&0 1
CreateProduct&&1 >
(&&> ?
productCreationDto&&? Q
)&&Q R
;&&R S
var(( 
domainProduct(( !
=((" #
new(($ '$
ProductInfrastructureDto((( @
{)) 
	ProductId** 
=** 

newProduct**  *
.*** +
	ProductId**+ 4
.**4 5
Value**5 :
,**: ;
Name++ 
=++ 

newProduct++ %
.++% &
Name++& *
,++* +
Status,, 
=,, 

newProduct,, '
.,,' (
Status,,( .
.,,. /
Value,,/ 4
,,,4 5
Stock-- 
=-- 

newProduct-- &
.--& '
Stock--' ,
,--, -
Description.. 
=..  !

newProduct.." ,
..., -
Description..- 8
,..8 9
Price// 
=// 

newProduct// &
.//& '
Price//' ,
}00 
;00 
await22 
_productRepository22 (
.22( )
AddAsync22) 1
(221 2
domainProduct222 ?
)22? @
;22@ A
var44 
createdEvent44  
=44! "
new44# &
ProductCreatedEvent44' :
(44: ;

newProduct44; E
)44E F
;44F G
await55 
_eventStore55 !
.55! "
Store55" '
(55' (
createdEvent55( 4
)554 5
;555 6
return77 
new77 )
ProductResponseApplicationDto77 8
{779 :
Success77; B
=77C D
true77E I
,77I J
Message77K R
=77S T
$str77U p
,77p q
CreatedProduct	77r Ä
=
77Å Ç

newProduct
77É ç
}
77é è
;
77è ê
}88 
catch99 
(99 
	Exception99 
ex99 
)99  
{:: 
return;; 
new;; )
ProductResponseApplicationDto;; 8
{;;9 :
Success;;; B
=;;C D
false;;E J
,;;J K
Message;;L S
=;;T U
ex;;V X
.;;X Y
Message;;Y `
};;a b
;;;b c
}<< 
}== 	
}>> 
}?? Ø
sD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\commands\UpdateProductCommand.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
commands3 ;
{ 
public 

class  
UpdateProductCommand %
:& '
IRequest( 0
<0 1$
UpdateProductResponseDto1 I
>I J
{ 
public '
ProductUpdateApplicationDto *
Product+ 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public

  
UpdateProductCommand

 #
(

# $'
ProductUpdateApplicationDto

$ ?
product

@ G
)

G H
{ 	
Product 
= 
product 
; 
} 	
} 
} ä"
zD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\commands\UpdateProductCommandHandler.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
commands3 ;
{ 
public 

class '
UpdateProductCommandHandler ,
:- .
IRequestHandler/ >
<> ? 
UpdateProductCommand? S
,S T$
UpdateProductResponseDtoU m
>m n
{ 
private		 
readonly		 
IProductRepository		 +
_productRepository		, >
;		> ?
public '
UpdateProductCommandHandler *
(* +
IProductRepository+ =
productRepository> O
)O P
{ 	
_productRepository 
=  
productRepository! 2
??3 5
throw6 ;
new< ?!
ArgumentNullException@ U
(U V
nameofV \
(\ ]
productRepository] n
)n o
)o p
;p q
} 	
public 
async 
Task 
< $
UpdateProductResponseDto 2
>2 3
Handle4 :
(: ; 
UpdateProductCommand; O
requestP W
,W X
CancellationTokenY j
cancellationTokenk |
)| }
{ 	
var 
existingProduct 
=  !
await" '
_productRepository( :
.: ;
GetByIdAsync; G
(G H
requestH O
.O P
ProductP W
.W X
	ProductIdX a
)a b
;b c
if 
( 
existingProduct 
==  "
null# '
)' (
{ 
return 
new $
UpdateProductResponseDto 3
{ 
Success 
= 
false #
,# $
Message 
= 
$str 2
} 
; 
} 
existingProduct 
. 
Name  
=! "
request# *
.* +
Product+ 2
.2 3
Name3 7
;7 8
existingProduct 
. 
Status "
=# $
request% ,
., -
Product- 4
.4 5
Status5 ;
;; <
existingProduct 
. 
Stock !
=" #
request$ +
.+ ,
Product, 3
.3 4
Stock4 9
;9 :
existingProduct 
. 
Description '
=( )
request* 1
.1 2
Product2 9
.9 :
Description: E
;E F
existingProduct   
.   
Price   !
=  " #
request  $ +
.  + ,
Product  , 3
.  3 4
Price  4 9
;  9 :
await"" 
_productRepository"" $
.""$ %
UpdateAsync""% 0
(""0 1
existingProduct""1 @
)""@ A
;""A B
return$$ 
new$$ $
UpdateProductResponseDto$$ /
{%% 
Success&& 
=&& 
true&& 
,&& 
Message'' 
='' 
$str'' 9
,''9 :
UpdatedProduct(( 
=((  
new((! $'
ProductUpdateApplicationDto((% @
{)) 
	ProductId** 
=** 
existingProduct**! 0
.**0 1
	ProductId**1 :
,**: ;
Name++ 
=++ 
existingProduct++ *
.++* +
Name+++ /
,++/ 0
Status,, 
=,, 
existingProduct,, ,
.,,, -
Status,,- 3
,,,3 4
Stock-- 
=-- 
existingProduct-- +
.--+ ,
Stock--, 1
,--1 2
Description.. 
=..  !
existingProduct.." 1
...1 2
Description..2 =
,..= >
Price// 
=// 
existingProduct// +
.//+ ,
Price//, 1
}00 
}11 
;11 
}22 	
}44 
}55 ‰
pD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\dto\DiscountApplicationDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
dto3 6
{ 
public 

class "
DiscountApplicationDto '
{ 
public 
required 
string 
Id !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
int 
DiscountPercent "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} Í
oD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\dto\ProductApplicationDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
dto3 6
{ 
public 

class !
ProductApplicationDto &
{ 
public		 
string		 
?		 
	ProductId		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Range	 
( 
$num 
, 
$num 
) 
] 
public 
int 
Status 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
? 

StatusName !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
) 
]  
public 
int 
Stock 
{ 
get 
; 
set  #
;# $
}% &
[ 	
Required	 
] 
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Range	 
( 
$num 
, 
double 
. 
MaxValue $
)$ %
]% &
public 
decimal 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
Range	 
( 
$num 
, 
$num 
) 
] 
public 
decimal 
? 
Discount  
{! "
get# &
;& '
set( +
;+ ,
}- .
public   
decimal   

FinalPrice   !
{  " #
get  $ '
;  ' (
set  ) ,
;  , -
}  . /
}"" 
}## Ô
vD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\dto\ProductRequestApplicationDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
dto3 6
{ 
public 

class (
ProductRequestApplicationDto -
{ 
public 
string 
? 
	ProductId  
{! "
get# &
;& '
set( +
;+ ,
}- .
[		 	
Required			 
]		 
[

 	
StringLength

	 
(

 
$num

 
)

 
]

 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Range	 
( 
$num 
, 
$num 
) 
] 
public 
int 
Status 
{ 
get 
;  
set! $
;$ %
}& '
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
) 
]  
public 
int 
Stock 
{ 
get 
; 
set  #
;# $
}% &
[ 	
Required	 
] 
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Range	 
( 
$num 
, 
double 
. 
MaxValue $
)$ %
]% &
public 
decimal 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ú
wD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\dto\ProductResponseApplicationDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
dto3 6
{ 
public 

class )
ProductResponseApplicationDto .
{ 
public 
bool 
Success 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
public  
ProductManagementAPI #
.# $
Product$ +
.+ ,
Domain, 2
.2 3

aggregates3 =
.= >
Product> E
CreatedProductF T
{U V
getW Z
;Z [
set\ _
;_ `
}a b
} 
}		 ƒ
iD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\dto\ProductStateDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
dto3 6
{ 
public 

class 
ProductStateDto  
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
} 
} í
uD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\dto\ProductUpdateApplicationDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
dto3 6
{ 
public 

class '
ProductUpdateApplicationDto ,
{ 
[ 	
Required	 
] 
public		 
string		 
	ProductId		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Range	 
( 
$num 
, 
$num 
) 
] 
public 
int 
Status 
{ 
get 
;  
set! $
;$ %
}& '
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
) 
]  
public 
int 
Stock 
{ 
get 
; 
set  #
;# $
}% &
[ 	
Required	 
] 
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Range	 
( 
$num 
, 
double 
. 
MaxValue $
)$ %
]% &
public 
decimal 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} á
rD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\dto\UpdateProductResponseDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
dto3 6
{ 
public 

class $
UpdateProductResponseDto )
{ 
public 
bool 
Success 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
public '
ProductUpdateApplicationDto *
UpdatedProduct+ 9
{: ;
get< ?
;? @
setA D
;D E
}F G
} 
}		 ª
pD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\events\ProductCreatedEvent.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .
events. 4
{ 
public 

class 
ProductCreatedEvent $
{ 
public 
string 
	ProductId 
{  !
get" %
;% &
private' .
set/ 2
;2 3
}4 5
public 
string 
Name 
{ 
get  
;  !
private" )
set* -
;- .
}/ 0
public		 
decimal		 
Price		 
{		 
get		 "
;		" #
private		$ +
set		, /
;		/ 0
}		1 2
public

 
ProductCreatedEvent

 "
(

" # 
ProductManagementAPI

# 7
.

7 8
Product

8 ?
.

? @
Domain

@ F
.

F G

aggregates

G Q
.

Q R
Product

R Y
product

Z a
)

a b
{ 	
	ProductId 
= 
product 
.  
	ProductId  )
.) *
Value* /
;/ 0
Name 
= 
product 
. 
Name 
;  
Price 
= 
product 
. 
Price !
;! "
} 	
} 
} Ò
mD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\events\SimpleEventStore.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
events3 9
{ 
public 

class 
SimpleEventStore !
:" #
IEventStore$ /
{ 
public 
async 
Task 
Store 
<  
TEvent  &
>& '
(' (
TEvent( .
@event/ 5
)5 6
where7 <
TEvent= C
:D E
classF K
{ 	
Console		 
.		 
	WriteLine		 
(		 
$"		  
$str		  3
{		3 4
@event		4 :
.		: ;
GetType		; B
(		B C
)		C D
.		D E
Name		E I
}		I J
"		J K
)		K L
;		L M
await

 
Task

 
.

 
CompletedTask

 $
;

$ %
} 	
} 
} õ
kD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\handlers\ErrorHandler.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
handlers3 ;
{ 
public 

static 
class 
ErrorHandler $
{ 
public 
static !
ProductApplicationDto +(
HandleProductCreationFailure, H
(H I)
ProductResponseApplicationDtoI f
responseg o
)o p
{ 	
return 
new !
ProductApplicationDto ,
{ 
	ProductId 
= 
null  
,  !
Name 
= 
$str :
,: ;
Status 
= 
$num 
, 
Stock 
= 
$num 
, 
Description 
= 
$"  
$str  '
{' (
response( 0
.0 1
Message1 8
}8 9
"9 :
,: ;
Price 
= 
$num 
, 
Discount 
= 
null 
,  

FinalPrice 
= 
$num 
} 
; 
} 	
} 
} É
uD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\helpers\ProductValidationHelper.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
helpers3 :
{ 
public 

static 
class #
ProductValidationHelper /
{ 
public 
static 
void 
EnsureNotNull (
<( )
T) *
>* +
(+ ,
T, -
obj. 1
,1 2
string3 9
errorMessage: F
)F G
whereH M
TN O
:P Q
classR W
{ 	
if 
( 
obj 
== 
null 
) 
throw 
new  
ApplicationException .
(. /
errorMessage/ ;
); <
;< =
}		 	
}

 
} â
lD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IEventStore.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface 
IEventStore  
{ 
Task 
Store 
< 
TEvent 
> 
( 
TEvent !
@event" (
)( )
where* /
TEvent0 6
:7 8
class9 >
;> ?
} 
} Ú
xD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IGetDiscountByIdUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface #
IGetDiscountByIdUseCase ,
{ 
Task 
< "
DiscountApplicationDto #
># $
ExecuteAsync% 1
(1 2
string2 8
	productId9 B
)B C
;C D
} 
}		 Ô
wD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IGetProductByIdUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface "
IGetProductByIdUseCase +
{ 
Task 
< !
ProductApplicationDto "
>" #
ExecuteAsync$ 0
(0 1
string1 7
	productId8 A
)A B
;B C
} 
}		 Ó
|D:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IGetProductStateByIdUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface '
IGetProductStateByIdUseCase 0
{ 
Task 
< 
ProductStateDto 
> 
ExecuteAsync *
(* +
int+ .
stateId/ 6
)6 7
;7 8
} 
}		 ˘
yD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IGetProductStatesUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface $
IGetProductStatesUseCase -
{ 
Task 
< 
IEnumerable 
< 
ProductStateDto (
>( )
>) *
ExecuteAsync+ 7
(7 8
)8 9
;9 :
} 
}		 è
vD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IProductCreateUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface !
IProductCreateUseCase *
{ 
Task		 
<		 )
ProductResponseApplicationDto		 *
>		* +
CreateProductAsync		, >
(		> ?(
ProductRequestApplicationDto		? [
request		\ c
)		c d
;		d e
}

 
} Ô
wD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IProductDetailsUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface "
IProductDetailsUseCase +
{ 
Task 
< !
ProductApplicationDto "
>" #
GetByIdAsync$ 0
(0 1
string1 7
	productId8 A
)A B
;B C
} 
}		 ¶
pD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IProductService.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface 
IProductService $
{ 
Task 
< !
ProductApplicationDto "
>" #
CreateProductAsync$ 6
(6 7!
ProductApplicationDto7 L

productDtoM W
)W X
;X Y
Task 
< !
ProductApplicationDto "
>" #
GetProductByIdAsync$ 7
(7 8
string8 >
id? A
)A B
;B C
Task		 
<		 $
UpdateProductResponseDto		 %
>		% &
UpdateProductAsync		' 9
(		9 :'
ProductUpdateApplicationDto		: U
productUpdateDto		V f
)		f g
;		g h
}

 
} Ù
uD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IProductStateService.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface  
IProductStateService )
{ 
Task 
< 
IEnumerable 
< 
ProductStateDto (
>( )
>) *
LoadStatesAsync+ :
(: ;
); <
;< =
} 
}		 â
vD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\interfaces\IProductUpdateUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3

interfaces3 =
{ 
public 

	interface !
IProductUpdateUseCase *
{ 
Task 
< $
UpdateProductResponseDto %
>% &
UpdateProductAsync' 9
(9 :'
ProductUpdateApplicationDto: U
requestV ]
)] ^
;^ _
} 
}		 å%
rD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\mappers\GetProductByIdMapper.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
mappers3 :
{ 
public 

static 
class  
GetProductByIdMapper ,
{ 
public		 
static		 
Product		 
.		 
Domain		 $
.		$ %

aggregates		% /
.		/ 0
Product		0 7
MapToDomainEntity		8 I
(		I J!
ProductApplicationDto		J _

productDto		` j
)		j k
{

 	
if 
( 

productDto 
== 
null "
)" #
throw 
new !
ArgumentNullException /
(/ 0
nameof0 6
(6 7

productDto7 A
)A B
)B C
;C D
return 
new 
Product 
. 
Domain %
.% &

aggregates& 0
.0 1
Product1 8
(8 9
new 
	ProductId 
( 

productDto (
.( )
	ProductId) 2
)2 3
,3 4

productDto 
. 
Name 
,  

productDto 
. 
Price  
,  !

productDto 
. 
Stock  
,  !

productDto 
. 
Description &
,& '
new 
ProductStatus !
(! "

productDto" ,
., -
Status- 3
)3 4
) 
; 
} 	
public 
static !
ProductApplicationDto +
MapToApplicationDto, ?
(? @
Product 
. 
Domain 
. 

aggregates %
.% &
Product& -
product. 5
,5 6
ProductStateDto 
	statusDto %
,% &"
DiscountApplicationDto "
discountDto# .
). /
{ 	
if 
( 
product 
== 
null 
)  
throw 
new !
ArgumentNullException /
(/ 0
nameof0 6
(6 7
product7 >
)> ?
)? @
;@ A
if 
( 
	statusDto 
== 
null !
)! "
throw   
new   !
ArgumentNullException   /
(  / 0
nameof  0 6
(  6 7
	statusDto  7 @
)  @ A
)  A B
;  B C
if!! 
(!! 
discountDto!! 
==!! 
null!! #
)!!# $
throw"" 
new"" !
ArgumentNullException"" /
(""/ 0
nameof""0 6
(""6 7
discountDto""7 B
)""B C
)""C D
;""D E
product$$ 
.$$ 
ApplyDiscount$$ !
($$! "
new$$" %
Discount$$& .
($$. /
discountDto$$/ :
.$$: ;
DiscountPercent$$; J
)$$J K
)$$K L
;$$L M
var%% 

finalPrice%% 
=%% 
product%% $
.%%$ %
CalculateFinalPrice%%% 8
(%%8 9
)%%9 :
;%%: ;
return'' 
new'' !
ProductApplicationDto'' ,
{(( 
	ProductId)) 
=)) 
product)) #
.))# $
	ProductId))$ -
.))- .
ToString)). 6
())6 7
)))7 8
,))8 9
Name** 
=** 
product** 
.** 
Name** #
,**# $
Status++ 
=++ 
product++  
.++  !
Status++! '
.++' (
Value++( -
,++- .

StatusName,, 
=,, 
	statusDto,, &
.,,& '
Name,,' +
,,,+ ,
Stock-- 
=-- 
product-- 
.--  
Stock--  %
,--% &
Description.. 
=.. 
product.. %
...% &
Description..& 1
,..1 2
Price// 
=// 
product// 
.//  
Price//  %
,//% &
Discount00 
=00 
discountDto00 &
.00& '
DiscountPercent00' 6
,006 7

FinalPrice11 
=11 

finalPrice11 '
}22 
;22 
}33 	
}44 
}55 é
kD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\mappers\ProductMapper.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
mappers3 :
{ 
public 

static 
class 
ProductMapper %
{ 
public 
static (
ProductRequestApplicationDto 2
MapToProductRequest3 F
(F G!
ProductApplicationDtoG \
dto] `
)` a
{ 	
return		 
new		 (
ProductRequestApplicationDto		 3
{

 
Name 
= 
dto 
. 
Name 
,  
Status 
= 
dto 
. 
Status #
,# $
Stock 
= 
dto 
. 
Stock !
,! "
Description 
= 
dto !
.! "
Description" -
,- .
Price 
= 
dto 
. 
Price !
} 
; 
} 	
public 
static !
ProductApplicationDto +
ToApplicationDto, <
(< = 
ProductManagementAPI= Q
.Q R
ProductR Y
.Y Z
DomainZ `
.` a

aggregatesa k
.k l
Productl s
productt {
){ |
{ 	
return 
new !
ProductApplicationDto ,
{ 
	ProductId 
= 
product #
.# $
	ProductId$ -
.- .
Value. 3
,3 4
Name 
= 
product 
. 
Name #
,# $
Status 
= 
product  
.  !
Status! '
.' (
Value( -
,- .
Stock 
= 
product 
.  
Stock  %
,% &
Description 
= 
product %
.% &
Description& 1
,1 2
Price 
= 
product 
.  
Price  %
} 
; 
} 	
}!! 
}"" ö
qD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\queries\GetProductByIdQuery.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
queries3 :
{ 
public 

class 
GetProductByIdQuery $
:% &
IRequest' /
</ 0!
ProductApplicationDto0 E
>E F
{ 
public 
string 
	ProductId 
{  !
get" %
;% &
private' .
set/ 2
;2 3
}4 5
public

 
GetProductByIdQuery

 "
(

" #
string

# )
	productId

* 3
)

3 4
{ 	
	ProductId 
= 
	productId !
;! "
} 	
} 
} á
xD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\queries\GetProductByIdQueryHandler.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
queries3 :
{ 
public 

class &
GetProductByIdQueryHandler +
:, -
IRequestHandler. =
<= >
GetProductByIdQuery> Q
,Q R!
ProductApplicationDtoS h
>h i
{ 
private		 
readonly		 
IProductRepository		 +
_productRepository		, >
;		> ?
public &
GetProductByIdQueryHandler )
() *
IProductRepository* <
productRepository= N
)N O
{ 	
_productRepository 
=  
productRepository! 2
;2 3
} 	
public 
async 
Task 
< !
ProductApplicationDto /
>/ 0
Handle1 7
(7 8
GetProductByIdQuery8 K
requestL S
,S T
CancellationTokenU f
cancellationTokeng x
)x y
{ 	
var $
productInfrastructureDto (
=) *
await+ 0
_productRepository1 C
.C D
GetByIdAsyncD P
(P Q
requestQ X
.X Y
	ProductIdY b
)b c
;c d
if 
( $
productInfrastructureDto (
==) +
null, 0
)0 1
{ 
return 
null 
; 
} 
return 
new !
ProductApplicationDto ,
{ 
	ProductId 
= $
productInfrastructureDto 4
.4 5
	ProductId5 >
,> ?
Name 
= $
productInfrastructureDto /
./ 0
Name0 4
,4 5
Status 
= $
productInfrastructureDto 1
.1 2
Status2 8
,8 9
Stock 
= $
productInfrastructureDto 0
.0 1
Stock1 6
,6 7
Description 
= $
productInfrastructureDto 6
.6 7
Description7 B
,B C
Price 
= $
productInfrastructureDto 0
.0 1
Price1 6
,6 7
Discount   
=   
$num   
,   

FinalPrice!! 
=!! $
productInfrastructureDto!! 5
.!!5 6
Price!!6 ;
}"" 
;"" 
}## 	
}$$ 
}%% ¯
uD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\queries\GetProductDiscountQuery.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
queries3 :
{ 
public 

class #
GetProductDiscountQuery (
:) *
IRequest+ 3
<3 4"
DiscountApplicationDto4 J
>J K
{ 
public		 
	ProductId		 
	ProductId		 "
{		# $
get		% (
;		( )
}		* +
public #
GetProductDiscountQuery &
(& '
	ProductId' 0
	productId1 :
): ;
{ 	
	ProductId 
= 
	productId !
;! "
} 	
} 
} …
|D:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\queries\GetProductDiscountQueryHandler.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
queries3 :
{ 
public 

class *
GetProductDiscountQueryHandler /
:0 1
IRequestHandler2 A
<A B#
GetProductDiscountQueryB Y
,Y Z"
DiscountApplicationDto[ q
>q r
{ 
private		 
readonly		 
IDiscountRepository		 ,
_discountRepository		- @
;		@ A
public *
GetProductDiscountQueryHandler -
(- .
IDiscountRepository. A
discountRepositoryB T
)T U
{ 	
_discountRepository 
=  !
discountRepository" 4
;4 5
} 	
public 
async 
Task 
< "
DiscountApplicationDto 0
>0 1
Handle2 8
(8 9#
GetProductDiscountQuery9 P
requestQ X
,X Y
CancellationTokenZ k
cancellationTokenl }
)} ~
{ 	
var 
discountDomainDto !
=" #
await$ )
_discountRepository* =
.= >&
GetDiscountForProductAsync> X
(X Y
requestY `
.` a
	ProductIda j
.j k
Valuek p
)p q
;q r
return 
new "
DiscountApplicationDto -
{ 
Id 
= 
discountDomainDto &
.& '
Id' )
,) *
DiscountPercent 
=  !
discountDomainDto" 3
.3 4
DiscountPercent4 C
} 
; 
} 	
} 
} ´
vD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\queries\GetProductStateByIdQuery.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
queries3 :
{ 
public 

class $
GetProductStateByIdQuery )
:* +
IRequest, 4
<4 5
ProductStateDto5 D
>D E
{ 
public 
int 
? 
StateId 
{ 
get !
;! "
set# &
;& '
}( )
}		 
}

 ÷
}D:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\queries\GetProductStateByIdQueryHandler.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
queries3 :
{ 
public 

class +
GetProductStateByIdQueryHandler 0
:1 2
IRequestHandler3 B
<B C$
GetProductStateByIdQueryC [
,[ \
ProductStateDto] l
>l m
{ 
private		 
readonly		 
IMemoryCache		 %
_cache		& ,
;		, -
public +
GetProductStateByIdQueryHandler .
(. /
IMemoryCache/ ;
cache< A
)A B
{ 	
_cache 
= 
cache 
; 
} 	
public 
Task 
< 
ProductStateDto #
># $
Handle% +
(+ ,$
GetProductStateByIdQuery, D
requestE L
,L M
CancellationTokenN _
cancellationToken` q
)q r
{ 	
var 
states 
= 
_cache 
.  
Get  #
<# $
IEnumerable$ /
</ 0
ProductStateDto0 ?
>? @
>@ A
(A B
$strB Q
)Q R
;R S
var 
state 
= 
states 
? 
.  
FirstOrDefault  .
(. /
s/ 0
=>1 3
s4 5
.5 6
Id6 8
==9 ;
request< C
.C D
StateIdD K
)K L
?? 
throw  
new! $ 
KeyNotFoundException% 9
(9 :
$": <
$str< S
{S T
requestT [
.[ \
StateId\ c
}c d
$strd e
"e f
)f g
;g h
return 
Task 
. 

FromResult "
(" #
state# (
)( )
;) *
} 	
} 
} µ
sD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\queries\GetProductStatesQuery.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
queries3 :
{ 
public 

class !
GetProductStatesQuery &
:' (
IRequest) 1
<1 2
IEnumerable2 =
<= >
ProductStateDto> M
>M N
>N O
{ 
} 
}		 ‰
zD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\queries\GetProductStatesQueryHandler.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
queries3 :
{ 
public 

class (
GetProductStatesQueryHandler -
:. /
IRequestHandler0 ?
<? @!
GetProductStatesQuery@ U
,U V
IEnumerableW b
<b c
ProductStateDtoc r
>r s
>s t
{		 
private

 
readonly

 #
IProductStateRepository

 0%
_estadoProductoRepository

1 J
;

J K
public (
GetProductStatesQueryHandler +
(+ ,#
IProductStateRepository, C$
estadoProductoRepositoryD \
)\ ]
{ 	%
_estadoProductoRepository %
=& '$
estadoProductoRepository( @
;@ A
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
ProductStateDto& 5
>5 6
>6 7
Handle8 >
(> ?!
GetProductStatesQuery? T
requestU \
,\ ]
CancellationToken^ o
cancellationToken	p Å
)
Å Ç
{ 	
var 
estados 
= 
await %
_estadoProductoRepository  9
.9 :!
GetProductStatesAsync: O
(O P
)P Q
;Q R
return 
estados 
. 
Select !
(! "
estado" (
=>) +
new, /
ProductStateDto0 ?
{ 
Id 
= 
estado 
. 
Id 
, 
Name 
= 
estado 
. 
Name "
} 
) 
. 
ToList 
( 
) 
; 
} 	
} 
} é%
tD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\services\EstadoProductoService.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
services3 ;
{ 
public 

class 
ProductStateService $
:% & 
IProductStateService' ;
{		 
private

 
const

 
string

 
CacheKey

 %
=

& '
$str

( 7
;

7 8
private 
readonly $
IGetProductStatesUseCase 1$
_getProductStatesUseCase2 J
;J K
private 
readonly 
IMemoryCache %
_cache& ,
;, -
private 
readonly 
ILogger  
<  !
ProductStateService! 4
>4 5
_logger6 =
;= >
public 
ProductStateService "
(" #$
IGetProductStatesUseCase# ;#
getProductStatesUseCase< S
,S T
IMemoryCacheU a
cacheb g
,g h
ILoggeri p
<p q 
ProductStateService	q Ñ
>
Ñ Ö
logger
Ü å
)
å ç
{ 	$
_getProductStatesUseCase $
=% &#
getProductStatesUseCase' >
??? A
throwB G
newH K!
ArgumentNullExceptionL a
(a b
nameofb h
(h i$
getProductStatesUseCase	i Ä
)
Ä Å
)
Å Ç
;
Ç É
_cache 
= 
cache 
?? 
throw #
new$ '!
ArgumentNullException( =
(= >
nameof> D
(D E
cacheE J
)J K
)K L
;L M
_logger 
= 
logger 
?? 
throw  %
new& )!
ArgumentNullException* ?
(? @
nameof@ F
(F G
loggerG M
)M N
)N O
;O P
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
ProductStateDto& 5
>5 6
>6 7
LoadStatesAsync8 G
(G H
)H I
{ 	
return 
await  
GetCachedStatesAsync -
(- .
). /
;/ 0
} 	
private 
async 
Task 
< 
IEnumerable &
<& '
ProductStateDto' 6
>6 7
>7 8 
GetCachedStatesAsync9 M
(M N
)N O
{ 	
if 
( 
! 
_cache 
. 
TryGetValue #
(# $
CacheKey$ ,
,, -
out. 1
IEnumerable2 =
<= >
ProductStateDto> M
>M N
cachedStatesO [
)[ \
)\ ]
{ 
_logger 
. 
LogInformation &
(& '
$str' a
)a b
;b c
cachedStates 
= 
await $$
_getProductStatesUseCase% =
.= >
ExecuteAsync> J
(J K
)K L
;L M
CacheProductStates   "
(  " #
cachedStates  # /
)  / 0
;  0 1
_logger!! 
.!! 
LogInformation!! &
(!!& '
$str!!' R
)!!R S
;!!S T
}"" 
else## 
{$$ 
_logger%% 
.%% 
LogInformation%% &
(%%& '
$str%%' X
)%%X Y
;%%Y Z
}&& 
return'' 
cachedStates'' 
;''  
}(( 	
private** 
void** 
CacheProductStates** '
(**' (
IEnumerable**( 3
<**3 4
ProductStateDto**4 C
>**C D
states**E K
)**K L
{++ 	
var,, 
cacheEntryOptions,, !
=,," #
new,,$ '#
MemoryCacheEntryOptions,,( ?
(,,? @
),,@ A
.-- !
SetAbsoluteExpiration-- &
(--& '
TimeSpan--' /
.--/ 0
FromMinutes--0 ;
(--; <
$num--< =
)--= >
)--> ?
;--? @
_cache.. 
... 
Set.. 
(.. 
CacheKey.. 
,..  
states..! '
,..' (
cacheEntryOptions..) :
)..: ;
;..; <
}// 	
}00 
}22 ﬁ=
mD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\services\ProductService.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
services3 ;
{ 
public 

class 
ProductService 
:  !
IProductService" 1
{		 
private

 
readonly

 !
IProductCreateUseCase

 .!
_productCreateUseCase

/ D
;

D E
private 
readonly '
IGetProductStateByIdUseCase 4 
_getStateByIdUseCase5 I
;I J
private 
readonly #
IGetDiscountByIdUseCase 0#
_getDiscountByIdUseCase1 H
;H I
private 
readonly "
IGetProductByIdUseCase /"
_getProductByIdUseCase0 F
;F G
private 
readonly !
IProductUpdateUseCase .!
_productUpdateUseCase/ D
;D E
public 
ProductService 
( !
IProductCreateUseCase   
productCreateUseCase! 5
,5 6'
IGetProductStateByIdUseCase &
getStateByIdUseCase' :
,: ;#
IGetDiscountByIdUseCase ""
getDiscountByIdUseCase# 9
,9 :"
IGetProductByIdUseCase !!
getProductByIdUseCase" 7
,7 8!
IProductUpdateUseCase   
productUpdateUseCase! 5
)5 6
{ 	!
_productCreateUseCase !
=" # 
productCreateUseCase$ 8
;8 9 
_getStateByIdUseCase  
=! "
getStateByIdUseCase# 6
;6 7#
_getDiscountByIdUseCase #
=$ %"
getDiscountByIdUseCase& <
;< ="
_getProductByIdUseCase "
=# $!
getProductByIdUseCase% :
;: ;!
_productUpdateUseCase !
=" # 
productUpdateUseCase$ 8
;8 9
} 	
public55 
async55 
Task55 
<55 !
ProductApplicationDto55 /
>55/ 0
CreateProductAsync551 C
(55C D!
ProductApplicationDto55D Y

productDto55Z d
)55d e
{66 	
try77 
{88 
var99 
request99 
=99  
ProductManagementAPI99 2
.992 3
Product993 :
.99: ;
Application99; F
.99F G
mappers99G N
.99N O
ProductMapper99O \
.99\ ]
MapToProductRequest99] p
(99p q

productDto99q {
)99{ |
;99| }
var:: 
response:: 
=:: 
await:: $!
_productCreateUseCase::% :
.::: ;
CreateProductAsync::; M
(::M N
request::N U
)::U V
;::V W
if<< 
(<< 
!<< 
response<< 
.<< 
Success<< %
)<<% &
{== 
return>>  
ProductManagementAPI>> /
.>>/ 0
Product>>0 7
.>>7 8
Application>>8 C
.>>C D
handlers>>D L
.>>L M
ErrorHandler>>M Y
.>>Y Z(
HandleProductCreationFailure>>Z v
(>>v w
response>>w 
)	>> Ä
;
>>Ä Å
}?? 
returnAA  
ProductManagementAPIAA +
.AA+ ,
ProductAA, 3
.AA3 4
ApplicationAA4 ?
.AA? @
mappersAA@ G
.AAG H
ProductMapperAAH U
.AAU V
ToApplicationDtoAAV f
(AAf g
responseAAg o
.AAo p
CreatedProductAAp ~
)AA~ 
;	AA Ä
}BB 
catchCC 
(CC 
	ExceptionCC 
exCC 
)CC  
{DD 
throwEE 
newEE  
ApplicationExceptionEE .
(EE. /
$"EE/ 1
$strEE1 H
{EEH I
exEEI K
.EEK L
MessageEEL S
}EES T
"EET U
,EEU V
exEEW Y
)EEY Z
;EEZ [
}FF 
}GG 	
publicYY 
asyncYY 
TaskYY 
<YY !
ProductApplicationDtoYY /
>YY/ 0
GetProductByIdAsyncYY1 D
(YYD E
stringYYE K
idYYL N
)YYN O
{ZZ 	
try[[ 
{\\ 
var]] 

productDto]] 
=]]  
await]]! &"
_getProductByIdUseCase]]' =
.]]= >
ExecuteAsync]]> J
(]]J K
id]]K M
)]]M N
;]]N O#
ProductValidationHelper^^ '
.^^' (
EnsureNotNull^^( 5
(^^5 6

productDto^^6 @
,^^@ A
$"^^B D
$str^^D T
{^^T U
id^^U W
}^^W X
$str^^X c
"^^c d
)^^d e
;^^e f
var`` 
discountDto`` 
=``  !
await``" '#
_getDiscountByIdUseCase``( ?
.``? @
ExecuteAsync``@ L
(``L M
id``M O
)``O P
;``P Q#
ProductValidationHelperaa '
.aa' (
EnsureNotNullaa( 5
(aa5 6
discountDtoaa6 A
,aaA B
$"aaC E
$straaE ]
{aa] ^
idaa^ `
}aa` a
$straaa l
"aal m
)aam n
;aan o
varcc 
	statusDtocc 
=cc 
awaitcc  % 
_getStateByIdUseCasecc& :
.cc: ;
ExecuteAsynccc; G
(ccG H

productDtoccH R
.ccR S
StatusccS Y
)ccY Z
;ccZ [#
ProductValidationHelperdd '
.dd' (
EnsureNotNulldd( 5
(dd5 6
	statusDtodd6 ?
,dd? @
$"ddA C
$strddC Y
{ddY Z
idddZ \
}dd\ ]
$strdd] h
"ddh i
)ddi j
;ddj k
varff 
productff 
=ff  
GetProductByIdMapperff 2
.ff2 3
MapToDomainEntityff3 D
(ffD E

productDtoffE O
)ffO P
;ffP Q
returnhh  
GetProductByIdMapperhh +
.hh+ ,
MapToApplicationDtohh, ?
(hh? @
producthh@ G
,hhG H
	statusDtohhI R
,hhR S
discountDtohhT _
)hh_ `
;hh` a
}ii 
catchjj 
(jj 
	Exceptionjj 
exjj 
)jj  
{kk 
throwll 
newll  
ApplicationExceptionll .
(ll. /
$"ll/ 1
$strll1 d
{lld e
idlle g
}llg h
$strllh k
{llk l
exlll n
.lln o
Messagello v
}llv w
"llw x
,llx y
exllz |
)ll| }
;ll} ~
}mm 
}oo 	
publicqq 
asyncqq 
Taskqq 
<qq $
UpdateProductResponseDtoqq 2
>qq2 3
UpdateProductAsyncqq4 F
(qqF G'
ProductUpdateApplicationDtoqqG b
productUpdateDtoqqc s
)qqs t
{rr 	
tryss 
{tt 
returnuu 
awaituu !
_productUpdateUseCaseuu 2
.uu2 3
UpdateProductAsyncuu3 E
(uuE F
productUpdateDtouuF V
)uuV W
;uuW X
}vv 
catchww 
(ww 
	Exceptionww 
exww 
)ww  
{xx 
throwzz 
newzz  
ApplicationExceptionzz .
(zz. /
$"zz/ 1
$strzz1 H
{zzH I
exzzI K
.zzK L
MessagezzL S
}zzS T
"zzT U
,zzU V
exzzW Y
)zzY Z
;zzZ [
}{{ 
}|| 	
}~~ 
} »
uD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\usecases\GetDiscountByIdUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
usecases3 ;
{		 
public

 

class

 "
GetDiscountByIdUseCase

 '
:

( )#
IGetDiscountByIdUseCase

* A
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public "
GetDiscountByIdUseCase %
(% &
	IMediator& /
mediator0 8
)8 9
{ 	
	_mediator 
= 
mediator  
;  !
} 	
public 
async 
Task 
< "
DiscountApplicationDto 0
>0 1
ExecuteAsync2 >
(> ?
string? E
	productIdF O
)O P
{ 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
	productId* 3
)3 4
)4 5
{ 
throw 
new 
ArgumentException +
(+ ,
$str, V
,V W
nameofX ^
(^ _
	productId_ h
)h i
)i j
;j k
} 
var 
query 
= 
new #
GetProductDiscountQuery 3
(3 4
new4 7
	ProductId8 A
(A B
	productIdB K
)K L
)L M
;M N
var 
discountDto 
= 
await #
	_mediator$ -
.- .
Send. 2
(2 3
query3 8
)8 9
;9 :
if 
( 
discountDto 
== 
null #
)# $
{ 
return 
new "
DiscountApplicationDto 1
{   
Id!! 
=!! 
	productId!! "
,!!" #
DiscountPercent"" #
=""$ %
$num""& '
}## 
;## 
}$$ 
return&& 
new&& "
DiscountApplicationDto&& -
{'' 
Id(( 
=(( 
discountDto((  
.((  !
Id((! #
,((# $
DiscountPercent)) 
=))  !
discountDto))" -
.))- .
DiscountPercent)). =
}** 
;** 
}++ 	
},, 
}-- È

tD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\usecases\GetProductByIdUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
usecases3 ;
{ 
public 

class !
GetProductByIdUseCase &
:' ("
IGetProductByIdUseCase) ?
{		 
private

 
readonly

 
	IMediator

 "
	_mediator

# ,
;

, -
public !
GetProductByIdUseCase $
($ %
	IMediator% .
mediator/ 7
)7 8
{ 	
	_mediator 
= 
mediator  
;  !
} 	
public 
async 
Task 
< !
ProductApplicationDto /
>/ 0
ExecuteAsync1 =
(= >
string> D
	productIdE N
)N O
{ 	
var 
query 
= 
new 
GetProductByIdQuery /
(/ 0
	productId0 9
)9 :
;: ;
return 
await 
	_mediator "
." #
Send# '
(' (
query( -
)- .
;. /
} 	
} 
} ˆ
yD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\usecases\GetProductStateByIdUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
usecases3 ;
{ 
public 

class &
GetProductStateByIdUseCase +
:, -'
IGetProductStateByIdUseCase. I
{		 
private

 
readonly

 
	IMediator

 "
	_mediator

# ,
;

, -
public &
GetProductStateByIdUseCase )
() *
	IMediator* 3
mediator4 <
)< =
{ 	
	_mediator 
= 
mediator  
;  !
} 	
public 
async 
Task 
< 
ProductStateDto )
>) *
ExecuteAsync+ 7
(7 8
int8 ;
stateId< C
)C D
{ 	
var 
query 
= 
new $
GetProductStateByIdQuery 4
{5 6
StateId7 >
=? @
stateIdA H
}I J
;J K
var 
result 
= 
await 
	_mediator (
.( )
Send) -
(- .
query. 3
)3 4
;4 5
return 
result 
?? 
throw "
new# & 
KeyNotFoundException' ;
(; <
$str< N
)N O
;O P
} 	
} 
} ç

vD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\usecases\GetProductStatesUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
usecases3 ;
{ 
public		 

class		 #
GetProductStatesUseCase		 (
:		) *$
IGetProductStatesUseCase		+ C
{

 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public #
GetProductStatesUseCase &
(& '
	IMediator' 0
mediator1 9
)9 :
{ 	
	_mediator 
= 
mediator  
;  !
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
ProductStateDto& 5
>5 6
>6 7
ExecuteAsync8 D
(D E
)E F
{ 	
return 
await 
	_mediator "
." #
Send# '
(' (
new( +!
GetProductStatesQuery, A
(A B
)B C
)C D
;D E
} 	
} 
} ô
sD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\usecases\ProductCreateUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
usecases3 ;
{ 
public 

class  
ProductCreateUseCase %
:& '!
IProductCreateUseCase( =
{		 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public  
ProductCreateUseCase #
(# $
	IMediator$ -
mediator. 6
)6 7
{ 	
	_mediator 
= 
mediator  
;  !
} 	
public 
async 
Task 
< )
ProductResponseApplicationDto 7
>7 8
CreateProductAsync9 K
(K L(
ProductRequestApplicationDtoL h
requesti p
)p q
{ 	
try 
{ 
var 
command 
= 
new ! 
CreateProductCommand" 6
(6 7
request7 >
)> ?
;? @
return 
await 
	_mediator &
.& '
Send' +
(+ ,
command, 3
)3 4
;4 5
} 
catch 
( 
	Exception 
ex 
)  
{ 
return 
new )
ProductResponseApplicationDto 8
{ 
Success 
= 
false #
,# $
Message 
= 
$"  
$str  <
{< =
ex= ?
.? @
Message@ G
}G H
"H I
} 
; 
}   
}!! 	
}"" 
}## é
sD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextApplication\usecases\ProductUpdateUseCase.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Application' 2
.2 3
usecases3 ;
{ 
public 

class  
ProductUpdateUseCase %
:& '!
IProductUpdateUseCase( =
{ 
private		 
readonly		 
	IMediator		 "
	_mediator		# ,
;		, -
public  
ProductUpdateUseCase #
(# $
	IMediator$ -
mediator. 6
)6 7
{ 	
	_mediator 
= 
mediator  
;  !
} 	
public 
async 
Task 
< $
UpdateProductResponseDto 2
>2 3
UpdateProductAsync4 F
(F G'
ProductUpdateApplicationDtoG b
requestc j
)j k
{ 	
try 
{ 
var 
command 
= 
new ! 
UpdateProductCommand" 6
(6 7
request7 >
)> ?
;? @
return 
await 
	_mediator &
.& '
Send' +
(+ ,
command, 3
)3 4
;4 5
} 
catch 
( 
	Exception 
ex 
)  
{ 
return 
new $
UpdateProductResponseDto 3
{ 
Success 
= 
false #
,# $
Message 
= 
$"  
$str  8
{8 9
ex9 ;
.; <
Message< C
}C D
"D E
} 
; 
} 
} 	
}   
}!! 