//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Cool.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419




#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS3021 // Type or member does not need a CLSCompliant attribute because the assembly does not have a CLSCompliant attribute
#pragma warning disable CS0105 //The using directive for 'System.Collections.Generic' appeared previously in this namespace [D:\Desktop\projects\coolc\coolc\src\coolc\coolc.csproj


using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ICoolVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public partial class CoolBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, ICoolVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoolParser.program"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProgram([NotNull] CoolParser.ProgramContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoolParser.classdef"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitClassdef([NotNull] CoolParser.ClassdefContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>methodFeature</c>
	/// labeled alternative in <see cref="CoolParser.feature"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodFeature([NotNull] CoolParser.MethodFeatureContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>attribFeature</c>
	/// labeled alternative in <see cref="CoolParser.feature"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAttribFeature([NotNull] CoolParser.AttribFeatureContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoolParser.formal"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFormal([NotNull] CoolParser.FormalContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>lessExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitLessExp([NotNull] CoolParser.LessExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>identifierExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIdentifierExp([NotNull] CoolParser.IdentifierExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>assignExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAssignExp([NotNull] CoolParser.AssignExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>atsimExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAtsimExp([NotNull] CoolParser.AtsimExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>isvoidExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIsvoidExp([NotNull] CoolParser.IsvoidExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>boolExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitBoolExp([NotNull] CoolParser.BoolExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>lessEqualExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitLessEqualExp([NotNull] CoolParser.LessEqualExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>biggerEqualExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitBiggerEqualExp([NotNull] CoolParser.BiggerEqualExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>whileExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitWhileExp([NotNull] CoolParser.WhileExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>notExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNotExp([NotNull] CoolParser.NotExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>bracedExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitBracedExp([NotNull] CoolParser.BracedExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>letExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitLetExp([NotNull] CoolParser.LetExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>parentExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitParentExp([NotNull] CoolParser.ParentExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>equalsExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEqualsExp([NotNull] CoolParser.EqualsExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>ifExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIfExp([NotNull] CoolParser.IfExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>tildeExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTildeExp([NotNull] CoolParser.TildeExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>methodCallExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodCallExp([NotNull] CoolParser.MethodCallExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>newTypeExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNewTypeExp([NotNull] CoolParser.NewTypeExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>stringExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitStringExp([NotNull] CoolParser.StringExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>infixExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInfixExp([NotNull] CoolParser.InfixExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>intExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIntExp([NotNull] CoolParser.IntExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>biggerExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitBiggerExp([NotNull] CoolParser.BiggerExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>caseExp</c>
	/// labeled alternative in <see cref="CoolParser.expresion"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitCaseExp([NotNull] CoolParser.CaseExpContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoolParser.newvar"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNewvar([NotNull] CoolParser.NewvarContext context) { return VisitChildren(context); }
}
