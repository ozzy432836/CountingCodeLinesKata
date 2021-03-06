﻿Imports System.IO
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    Public theFile As String

    <TestInitialize> Public Sub Setup()
        theFile = Environment.CurrentDirectory & "\code.txt"

    End Sub

    <TestMethod()> Public Sub GetCwd()
        Dim cwd As String = Environment.CurrentDirectory()
        Assert.AreEqual("C:\Users\aosiname\Google Drive\VisualStudio\CountingCodeLinesKata\CountingCodeLines\bin\Debug", cwd)
    End Sub

    <TestMethod()> Public Sub CheckFileExistsAndIsNotEmpty()
        Dim value As String = File.ReadAllText(theFile)
        File.Exists(theFile)
        Assert.IsTrue(value.Length > 0)
    End Sub

    <TestMethod()> Public Sub FindCarriageReturn()
        Dim numLines As Integer = 0
        Dim value As String = File.ReadAllText(theFile)
        Debug.WriteLine(value)
        Dim carriagReturn = Chr(13) & Chr(10)
        Assert.IsTrue(InStr(value, carriagReturn) > 0)
    End Sub

    <TestMethod()> Public Sub CountCarriageReturns()
        Dim count As Integer = 0
        Dim tempString As String
        Dim value As String = File.ReadAllText(theFile)
        Dim carriagReturn = Chr(13) & Chr(10)



        While (InStr(value, carriagReturn) > 0)

            Dim x As Integer
            x = InStr(value, carriagReturn)
            value = Mid(value, x + 1)
            count += 1

        End While

        Assert.AreEqual(count, 6)

    End Sub

    ' we are here!
    <TestMethod()> Public Sub CountCodeLines()
        Dim count As Integer = 0
        Dim tempString As String

        Dim value As String = File.ReadAllText(theFile)
        Dim carriagReturn = Chr(13) & Chr(10)

        While (InStr(value, carriagReturn) > 0)
            Dim x As Integer
            x = InStr(value, carriagReturn)
            value = Mid(value, x + 1)
            tempString = Mid(value, 1, x)
            If Mid(tempString, 1, 2) = "//" Then

            Else
                count += 1
            End If
        End While

        Assert.AreEqual(count, 5)
    End Sub

End Class