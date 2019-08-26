.data 

	b: .word 0
.text

li $t2 8
sw $t2 b 
lw $a0 b
li $v0, 1
syscall 

