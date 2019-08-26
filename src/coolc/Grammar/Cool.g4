grammar Cool; 

@actionName 
{
	auto-parse-tree=off; //this isn't doing anything and does'n work for my project
}

@header {


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS3021 // Type or member does not need a CLSCompliant attribute because the assembly does not have a CLSCompliant attribute
#pragma warning disable CS0105 //The using directive for 'System.Collections.Generic' appeared previously in this namespace [D:\Desktop\projects\coolc\coolc\src\coolc\coolc.csproj

}
@members{

}

program : (classdef SEMICOLON)+ EOF
	;
classdef : CLASS t=TYPE (INHERITS it=TYPE)? LBRACE (feature SEMICOLON)* RBRACE
	;
feature : id=ID LPAREN (formal (COMMA formal)*)? RPAREN COLON t=TYPE LBRACE e=expresion RBRACE							#methodFeature
	| id=ID COLON t=TYPE (ASSIGN e=expresion)?																			#attribFeature
	;
formal : id=ID COLON t=TYPE
	;
expresion : expresion (ATSYM t=TYPE)? DOT id=ID LPAREN(expresion (COMMA expresion)*)?RPAREN								#atsimExp
	| id=ID LPAREN (expresion (COMMA expresion)* )? RPAREN
	{
		
		}																#methodCallExp
	| IF expresion THEN expresion ELSE expresion FI																		#ifExp	
	| WHILE le=expresion LOOP re=expresion POOL																			#whileExp
	| LBRACE (expresion SEMICOLON)+ RBRACE																				#bracedExp
	| LET newvar (COMMA newvar)* IN body=expresion																		#letExp
	| CASE expresion OF (ID COLON t=TYPE DARROW expresion SEMICOLON)+ ESAC												#caseExp
	| NEW t=TYPE																										#newTypeExp
	| ISVOID e=expresion																								#isvoidExp
	| le=expresion op=(STAR|SLASH) re=expresion																			#infixExp
	| le=expresion op=(PLUS|MINUS) re=expresion																			#infixExp
	| TILDE e=expresion																									#tildeExp
	| le=expresion LT re=expresion																						#lessExp
	| le=expresion BT re=expresion																						#biggerExp	
	| le=expresion LE re=expresion																						#lessEqualExp
	| le=expresion BE re=expresion
	| le=expresion EQUALS re=expresion																					#equalsExp
	| NOT e=expresion																									#notExp
	| LPAREN e=expresion RPAREN																							#parentExp
	| s=STRING																											#stringExp
	| i=INT																												#intExp
	| BOOL																												#boolExp
	| id=ID																												#identifierExp
	| id=ID ASSIGN e=expresion																							#assignExp
	;

newvar : id=ID COLON t=TYPE (ASSIGN e=expresion)?
	;
//| (ID | BOOL | INT | STRING )																						#constantExp




// note "lexer grammar"

// Operators

LPAREN		: '(' ;
RPAREN		: ')' ;
COLON		: ':' ;
ATSYM		: '@' ;
COMMA		: ',' ;
PLUS		: '+' ;
MINUS		: '-' ;
STAR		: '*' ;
SLASH		: '/' ;
TILDE		: '~' ;
LT			: '<' ;
BT			: '>' ;
EQUALS		: '=' ;
LBRACE		: '{' ;
RBRACE		: '}' ;
DOT			: '.' ;
LE			: '<=';
BE			: '>=';
ASSIGN		: '<-';
SEMICOLON   : ';' ;
DARROW      : '=>' ;


// Keywords are not case sensitive

CLASS		: ('c'|'C') ('l'|'L') ('a'|'A') ('s'|'S') ('s'|'S') ;
ELSE		: ('e'|'E') ('l'|'L') ('s'|'S') ('e'|'E') ;
FI			: ('f'|'F') ('i'|'I') ;
IF			: ('i'|'I') ('f'|'F') ;
IN			: ('i'|'I') ('n'|'N') ;
INHERITS	: ('i'|'I') ('n'|'N') ('h'|'H') ('e'|'E') ('r'|'R') ('i'|'I') ('t'|'T') ('s'|'S') ;
LET			: ('l'|'L') ('e'|'E') ('t'|'T') ;
LOOP		: ('l'|'L') ('o'|'O') ('o'|'O') ('p'|'P') ;
POOL		: ('p'|'P') ('o'|'O') ('o'|'O') ('l'|'L') ;
THEN		: ('t'|'T') ('h'|'H') ('e'|'E') ('n'|'N') ;
WHILE		: ('w'|'W') ('h'|'H') ('i'|'I') ('l'|'L') ('e'|'E') ;
CASE		: ('c'|'C') ('a'|'A') ('s'|'S') ('e'|'E') ;
ESAC		: ('e'|'E') ('s'|'S') ('a'|'A') ('c'|'C') ;
OF			: ('o'|'O') ('f'|'F') ;
NEW			: ('n'|'N') ('e'|'E') ('w'|'W') ;
ISVOID		: ('i'|'I') ('s'|'S') ('v'|'V') ('o'|'O') ('i'|'I') ('d'|'D') ;
NOT			: ('n'|'N') ('o'|'O') ('t'|'T') ;
//TRUE 		: 'true';
//FALSE       : 'false';

BOOL : 'true'| 'false';

ID : [a-z] [0-9_a-zA-Z]* ;
TYPE : [A-Z] [a-zA-Z0-9_]* ;


INT : '0' | [1-9] DIGIT* ;							// 0, -123, 9534
//FLOAT : '-'? DIGIT+ '.' DIGIT* | '-'? '.' DIGIT+ ;		// -1.3 -0.4, 234.567, .32


// we don't need this
//NUMBER : INT EXP 										// 1.35, -1.35E-9, 0.3e-12, -4.5
//		| FLOAT EXP
//;
//fragment EXP : [Ee] INT ;	
fragment DIGIT : [0-9];


STRING: '"' (ESC|.)*? '"' ;								//nongreedy subrules
fragment ESC : '\\"' | '\\\\' ; 						// 2-char sequences \" and \\


//BOOOL : 'true' | 'false' ;


WS : [ \t\n\r]+ -> skip ;						// toss out whitespace
LINE_COMMENT : '--' .*? ('\n'|'\r') -> skip ;	// consumes everything after // until it sees a newline
BLOCKCOMMENT : '(*' .*? '*)' -> skip; 			// match anything between (* and *)


