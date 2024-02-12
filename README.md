# Mcell
Excel-like program that is made for interacting with table and applying for cells a primitive mathematical expressions.

### Usage
At this moment commands can be hard-coded or be inputed by txt file.
Table itself is a two-dimensional grid. You can get acces to the cell by providing special commands in a text file (in future in UI). First two letters is coordinates of cell ,for example 'AB': A - by x axis , B - by y axis, nex symbol is command type : '=', ':', '-'.
Library supports two kinds of operations with cells, '=' for assignment a number value in a cell (now it supports only positive numbers), ':' for expressions, '-' for ranges first argument is start value second is incrementing value.

Example of commands :
```console
AA=1
AB=2
AC:AA+AB
AD:1+2
BA-BF=1,1
CA-CF:5+5
DA-DF:AA+AB
```
#### Available operations in cells
1. "+"
2. "-"
3. "/"
4. "*"
#### Avaliable mathematical functions in cells
1. Abs
2. Sin
3. Cos
4. Sqrt
#### Example of mathematical expression that is available in cells
```console
1+cos1*2
10+2+sqrt25
```