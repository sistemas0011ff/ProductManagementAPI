î
cD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\aggregates\Product.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .

aggregates. 8
{ 
public 

class 
Product 
{ 
public 
	ProductId 
	ProductId "
{# $
get% (
;( )
private* 1
set2 5
;5 6
}7 8
public		 
string		 
Name		 
{		 
get		  
;		  !
private		" )
set		* -
;		- .
}		/ 0
public

 
decimal

 
Price

 
{

 
get

 "
;

" #
private

$ +
set

, /
;

/ 0
}

1 2
public 
int 
Stock 
{ 
get 
; 
private  '
set( +
;+ ,
}- .
public 
string 
Description !
{" #
get$ '
;' (
private) 0
set1 4
;4 5
}6 7
public 
ProductStatus 
Status #
{$ %
get& )
;) *
private+ 2
set3 6
;6 7
}8 9
private 
Discount 
	_discount "
;" #
public 
Product 
( 
	ProductId  
	productId! *
,* +
string, 2
name3 7
,7 8
decimal9 @
priceA F
,F G
intH K
stockL Q
,Q R
stringS Y
descriptionZ e
,e f
ProductStatusg t
statusu {
){ |
{ 	
	ProductId 
= 
	productId !
;! "
Name 
= 
name 
; 
Price 
= 
price 
; 
Stock 
= 
stock 
; 
Description 
= 
description %
;% &
Status 
= 
status 
; 
} 	
public 
void 
ApplyDiscount !
(! "
Discount" *
discount+ 3
)3 4
{ 	
	_discount 
= 
discount  
;  !
} 	
public!! 
decimal!! 
CalculateFinalPrice!! *
(!!* +
)!!+ ,
{"" 	
return## 
	_discount## 
!=## 
null##  $
?##% &
Price##' ,
*##- .
(##/ 0
$num##0 3
-##4 5
	_discount##6 ?
.##? @

Percentage##@ J
)##J K
/##L M
$num##N Q
:##R S
Price##T Y
;##Y Z
}$$ 	
}&& 
}'' ƒ
`D:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\dto\DiscountDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .
dto. 1
{ 
public 

class 
DiscountDto 
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
} Ñ	
gD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\dto\ProductCreationDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .
dto. 1
{ 
public 

class 
ProductCreationDto #
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
decimal 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
Stock 
{ 
get 
; 
set  #
;# $
}% &
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
int		 
Status		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
}

 
} º

mD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\dto\ProductInfrastructureDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .
dto. 1
{ 
public 

class $
ProductInfrastructureDto )
{ 
public 
string 
? 
	ProductId  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
Status 
{ 
get 
;  
set! $
;$ %
}& '
public 
int 
Stock 
{ 
get 
; 
set  #
;# $
}% &
public		 
string		 
Description		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
public

 
decimal

 
Price

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
} 
} Œ

rD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\dto\ProductStateInfrastructureDto.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .
dto. 1
{ 
public 

class 
EstadosWrapper 
{ 
[ 	
JsonPropertyName	 
( 
$str #
)# $
]$ %
public 
List 
< )
ProductStateInfrastructureDto 1
>1 2
Estados3 :
{; <
get= @
;@ A
setB E
;E F
}G H
}		 
public 

class )
ProductStateInfrastructureDto .
{ 
[ 	
JsonPropertyName	 
( 
$str 
) 
]  
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
[ 	
JsonPropertyName	 
( 
$str "
)" #
]# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
} 
} â
bD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\entities\Discount.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .
entities. 6
{ 
public 

class 
Discount 
{ 
public 
int 

Percentage 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public 
Discount 
( 
int 

percentage &
)& '
{ 	

Percentage		 
=		 

percentage		 #
;		# $
}

 	
} 
} ÿ
gD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\factory\ProductFactory.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .
factory. 5
{ 
public 

class 
ProductFactory 
:  !
IProductFactory" 1
{ 
private		 
readonly		 #
IProductIdentityService		 0
_identityService		1 A
;		A B
public 
ProductFactory 
( #
IProductIdentityService 5
identityService6 E
)E F
{ 	
_identityService 
= 
identityService .
;. /
} 	
public  
ProductManagementAPI #
.# $
Product$ +
.+ ,
Domain, 2
.2 3

aggregates3 =
.= >
Product> E
CreateProductF S
(S T
ProductCreationDtoT f
productCreationDtog y
)y z
{ 	
var 
	productId 
= 
_identityService ,
., -
GenerateUniqueId- =
(= >
)> ?
;? @
var 
productStatus 
= 
new  #
ProductStatus$ 1
(1 2
productCreationDto2 D
.D E
StatusE K
)K L
;L M
var 
productIdValue 
=  
new! $
	ProductId% .
(. /
	productId/ 8
)8 9
;9 :
return 
new  
ProductManagementAPI +
.+ ,
Product, 3
.3 4
Domain4 :
.: ;

aggregates; E
.E F
ProductF M
(M N
productIdValue 
, 
productCreationDto "
." #
Name# '
,' (
productCreationDto "
." #
Price# (
,( )
productCreationDto "
." #
Stock# (
,( )
productCreationDto "
." #
Description# .
,. /
productStatus 
) 
; 
} 	
} 
} „
oD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\interfaces\IDiscountRepository.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .

interfaces. 8
{ 
public 

	interface 
IDiscountRepository (
{ 
Task 
< 
DiscountDto 
> &
GetDiscountForProductAsync 4
(4 5
string5 ;
	productId< E
)E F
;F G
} 
}		 Œ
kD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\interfaces\IProductFactory.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .

interfaces. 8
{ 
public 

	interface 
IProductFactory $
{  
ProductManagementAPI 
. 
Product $
.$ %
Domain% +
.+ ,

aggregates, 6
.6 7
Product7 >
CreateProduct? L
(L M
ProductCreationDtoM _
productCreationDto` r
)r s
;s t
} 
} Å
sD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\interfaces\IProductIdentityService.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .

interfaces. 8
{ 
public 

	interface #
IProductIdentityService ,
{ 
string 
GenerateUniqueId 
(  
)  !
;! "
} 
} Ÿ	
nD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\interfaces\IProductRepository.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .

interfaces. 8
{ 
public 

	interface 
IProductRepository '
{ 
Task 
AddAsync 
( $
ProductInfrastructureDto .
product/ 6
)6 7
;7 8
Task 
< 
IEnumerable 
< $
ProductInfrastructureDto 1
>1 2
>2 3
GetAllAsync4 ?
(? @
)@ A
;A B
Task		 
<		 $
ProductInfrastructureDto		 %
>		% &
GetByIdAsync		' 3
(		3 4
string		4 :
	productId		; D
)		D E
;		E F
Task

 
UpdateAsync

 
(

 $
ProductInfrastructureDto

 1
product

2 9
)

9 :
;

: ;
Task 
DeleteAsync 
( 
string 
	productId  )
)) *
;* +
} 
} Ñ
sD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\interfaces\IProductStateRepository.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .

interfaces. 8
{ 
public 

	interface #
IProductStateRepository ,
{ 
Task 
< 
IEnumerable 
< )
ProductStateInfrastructureDto 6
>6 7
>7 8!
GetProductStatesAsync9 N
(N O
)O P
;P Q
}		 
}

 à
pD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\services\ProductIdentityService.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .
services. 6
{ 
public 

class "
ProductIdentityService '
:( )#
IProductIdentityService* A
{ 
public 
string 
GenerateUniqueId &
(& '
)' (
{ 	
return		 
Guid		 
.		 
NewGuid		 
(		  
)		  !
.		! "
ToString		" *
(		* +
)		+ ,
;		, -
}

 	
} 
} Ã
gD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\valueObjects\ProductId.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Domain' -
.- .
valueObjects. :
{ 
public 

class 
	ProductId 
{ 
public 
string 
Value 
{ 
get !
;! "
private# *
set+ .
;. /
}0 1
public 
	ProductId 
( 
string 
value  %
)% &
{ 	
Value		 
=		 
value		 
;		 
}

 	
public 
override 
string 
ToString '
(' (
)( )
{ 	
return 
Value 
; 
} 	
} 
} é
kD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextDomain\valueObjects\ProductStatus.cs
	namespace 
 
ProductManagementAPI 
.  
Product  '
.' (
Domain( .
.. /
valueObjects/ ;
{ 
public 

class 
ProductStatus 
{ 
public 
int 
Value 
{ 
get 
; 
private  '
set( +
;+ ,
}- .
public 
ProductStatus 
( 
int  
value! &
)& '
{ 	
Value		 
=		 
value		 
;		 
}

 	
} 
} 