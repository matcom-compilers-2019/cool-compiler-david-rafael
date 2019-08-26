# coolc-output:
.data
self:	.word	0	#self
	Main_str:	.asciiz	"Main"
	x:	.word	0
.text
main:
	lw $fp, ($sp)
	addu $sp, $sp, 4
	subu $sp, $sp, 4 
	sw $fp, ($sp) 
# Method Call			out_int
# Method Call			exp
	li $t4 3 
	subu $sp, $sp, 4
	sw $t4 ($sp) 
	subu $sp, $sp, 4 
	sw $ra, ($sp) 
	jal exp 
	lw $ra, ($sp)
	addu $sp, $sp, 4
	move $t5 $v0		#Method return value_main 
	subu $sp, $sp, 4
	sw $t5 ($sp) 
	subu $sp, $sp, 4 
	sw $ra, ($sp) 
	jal out_int 
	lw $ra, ($sp)
	addu $sp, $sp, 4
	move $t6 $v0		#Method return value_main 
	li $v0, 10			# 10 is the exit syscall.
	syscall				# do the syscall.
exp:
	lw $fp, ($sp)
	addu $sp, $sp, 4
	lw $t0 ($sp) 
	addu $sp, $sp, 4
	sw $t0 x 
	subu $sp, $sp, 4 
	sw $fp, ($sp) 
	#if 
	lw $t2 x 
	li $t3 1 
	sge $t3 $t2 $t3 
	bne $t3 1 else1 
# Method Call			exp
	li $t5 2 
	lw $t4 x 
	div $t6 $t4 $t5 
	subu $sp, $sp, 4
	sw $t6 ($sp) 
	subu $sp, $sp, 4 
	sw $ra, ($sp) 
	jal exp 
	lw $ra, ($sp)
	addu $sp, $sp, 4
	move $t7 $v0		#Method return value_exp 
	li $t8 1 
	add $t0 $t7 $t8 
	move $t1 $t0 
	b endif1 
	else1:
	li $t1 1 
	move $t1 $t1 
	endif1:
	move $t2 $t1 
	move $v0 $t2 
	jr $ra				#end of method
### ### ### BASIC FUNCTIONS ### ### ###
out_string:
	lw $fp, ($sp)
	addu $sp, $sp, 4
	li $v0, 4			# syscall 4 (print_str)
	lw $a0, ($sp)		# argument: string
	syscall				# print the string
	subu $sp, $sp, 4 
	sw $fp, ($sp) 
	jr $ra				# jump back
out_int:
	lw $fp, ($sp)
	addu $sp, $sp, 4
	li $v0, 1			# syscall 1 (print_int)
	lw $a0, ($sp)		# argument: string
	syscall				# print the string
	subu $sp, $sp, 4 
	sw $fp, ($sp) 
	jr $ra				# jump back
length:
	lw $fp, ($sp)
	addu $sp, $sp, 4
	lw $t0, ($sp)
	addiu $t1,$zero,0
	lengthLoop:
		lb $t2, ($t0)
		beqz $t2, end_length_loop
		addiu $t0, $t0, 1
		addiu $t1, $t1, 1
		j lengthLoop
	end_length_loop:
	add $v0, $zero,$zero
	add $v0, $v0, $t1
	subu $sp, $sp, 4 
	sw $fp, ($sp) 
	jr $ra
in_int:
	lw $fp, ($sp)
	addu $sp, $sp, 4
	li $v0,5
	syscall
	subu $sp, $sp, 4 
	sw $fp, ($sp) 
	jr $ra
abort:
	li $v0, 10
	syscall
type_name:
li $v0, 10
syscall
copy:
li $v0, 10
syscall
concat:
li $v0, 10
syscall
substr:
li $v0, 10
syscall
### ### ### HELP FUNCTIONS ### ### ###
makeroom:
	lw $a0, ($sp)	# argument: int
	li $v0, 9		# 9 is the sbrk syscall.
	syscall			# do the syscall.
	jr $ra