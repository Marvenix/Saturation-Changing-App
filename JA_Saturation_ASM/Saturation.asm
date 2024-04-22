.data
array dword 8 dup (0) ;tablica s�u��ca do przechowywania danych z 2 pikseli
r9eq qword 0          ;zmienna zapamietuj�ca warto�� 4 argumentu funkcji, okre�laj�cego ile razy ma si� wykona� druga p�tla
r14eq qword 0         ;zmienna zapisuj�ca od kt�rego elementu tablicy ma si� zaczyna� wpisywanie zmienionych warto�ci do tablicy
r15eq qword 0         ;zmienna s�u��ca zapisaniu pierwotnej warto�ci rejestru R15 aby potem przed zako�czeniem programu m�c j� przywr�ci�

.code

Saturation proc

    mov r15eq, R15 ;zapisanie wartosci rejestru R15
    xor R11, R11   ;wyzerowanie rejestru R11
    xor R15, R15   ;wyzerowanie rejestru R15
    xor R13, R13   ;wyzerowanie rejestru R13
    lea R12, array ;przypisanie do R12 adresu tablicy array
    mov R14, rdx   ;przypisanie do R14 warto�ci od kt�rej ma si� zacz�� pobieranie, modyfikacja i wpisywanie danych do tablicy
    mov r14eq, rdx ;przypisanie do zmiennej r14eq warto�ci od kt�rej ma si� zacz�� pobieranie, modyfikacja i wpisywanie danych do tablicy

    ;wpisanie do rejestru AVX ymm7 warto�ci przez kt�re b�d� przemna�ane piksele (3 ostatnie argumenty funkcji)

    mov ebx, dword ptr [rsp + 48]
    mov array, ebx
    mov ebx, dword ptr [rsp + 56]
    mov array+4, ebx
    mov ebx, dword ptr [rsp + 64]
    mov array+8, ebx
    mov array+12, 3F800000h
    mov ebx, dword ptr [rsp + 48]
    mov array+16, ebx
    mov ebx, dword ptr [rsp + 56]
    mov array+20, ebx
    mov ebx, dword ptr [rsp + 64]
    mov array+24, ebx
    mov array+28, 3F800000h
    vmovups ymm7, ymmword ptr [array]

    ;wype�nienie rejestru ymm6 warto�ciami 255 aby potem por�wnuj�c z tym rejestrem 
    ;wyeliminowa� warto�ci wi�ksze ni� 255 powsta�e po przemno�eniu poszczeg�lnych warto�ci pikseli

    mov array, 437F0000h
    mov array+4, 437F0000h
    mov array+8, 437F0000h
    mov array+12, 437F0000h
    mov array+16, 437F0000h
    mov array+20, 437F0000h
    mov array+24, 437F0000h
    mov array+28, 437F0000h
    vmovups ymm6, ymmword ptr [array]

    ;sprawdzenie 3 argumentu funkcji (ile razy ma si� wykona� pierwsza p�tla). Je�li warto�� jest r�wna 0, mo�na przeskoczy� do wykonywania drugiej p�tli

    cmp R8, 0
    je restloop

    ;p�tla pobieraj�ce dane z tablicy wej�ciowej, zapisuj�ca je do tablicy array, aby potem wpisa� je do poszczeg�lnych rejestr�w

iteration_loop:
    mov eax, [RCX+R14*4] ;pobierz warto�� z tablicy wej�ciowej
    mov [R12+R15*4], eax ;zapisz warto�� w tablicy array
    inc R11              ;inkrementacja R11
    inc R15              ;inkrementacja R15 (u�ywana jest przy wpisywaniu danych do tablicy array)
    inc R14              ;inkrementacja R14 (u�ywana jest przy pobieraniu danych z tablicy wej�ciowej)
    inc R13              ;inkrementacja R13
    cmp R11, 8           ;je�eli R11 osi�gne�o warto�� 8 nast�pi wyj�cie z p�tli
    jl iteration_loop    
    xor R15, R15         ;zeruj R15
    xor R11, R11         ;zeruj R11
    cmp R13, 8           ;je�eli R13 jest r�wne 8 to wpisz do ymm15 dane z tablicy array, je�eli nie to przejd� dalej
    jne a1               ;(R13 jest wielokrotno�ci� liczby 8 i wskazuje ile razy wykona�a si� p�tla iteration_loop - 
                         ;je�eli 8 to trzeba wpisa� do ymm15, je�eli 16 to ymm14 itd.)
    vmovups ymm15, ymmword ptr [array]
    jmp iteration_loop
a1: cmp R13, 16
    jne a2
    vmovups ymm14, ymmword ptr [array]
    jmp iteration_loop
a2: cmp R13, 24
    jne a3
    vmovups ymm13, ymmword ptr [array]
    jmp iteration_loop
a3: cmp R13, 32
    jne a4
    vmovups ymm12, ymmword ptr [array]
    jmp iteration_loop
a4: cmp R13, 40
    jne a5
    vmovups ymm11, ymmword ptr [array]
    jmp iteration_loop
a5: cmp R13, 48
    jne a6
    vmovups ymm10, ymmword ptr [array]
    jmp iteration_loop
a6: cmp R13, 56
    jne a7
    vmovups ymm9, ymmword ptr [array]
    jmp iteration_loop
a7: vmovups ymm8, ymmword ptr [array]
    
    ;przemn� warto�ci pikseli umieszczone w rejestrach ymm15-ymm8 przez dane zawarte w ymm7

    vmulps ymm15, ymm7, ymm15
    vmulps ymm14, ymm7, ymm14
    vmulps ymm13, ymm7, ymm13
    vmulps ymm12, ymm7, ymm12
    vmulps ymm11, ymm7, ymm11
    vmulps ymm10, ymm7, ymm10
    vmulps ymm9, ymm7, ymm9
    vmulps ymm8, ymm7, ymm8

    ;je�eli jaka� warto�� jest wi�ksza ni� 255 to zast�p j� warto�ci� 255

    vminps ymm15, ymm15, ymm6
    vminps ymm14, ymm14, ymm6
    vminps ymm13, ymm13, ymm6
    vminps ymm12, ymm12, ymm6
    vminps ymm11, ymm11, ymm6
    vminps ymm10, ymm10, ymm6
    vminps ymm9, ymm9, ymm6
    vminps ymm8, ymm8, ymm6

    mov R14, r14eq
    xor R11, R11
    xor R15, R15
    xor R13, R13

    vmovups ymmword ptr [array], ymm15
iteration_loop2:
    mov eax, [R12+R15*4]
    mov [RCX+R14*4], eax
    inc R11
    inc R15
    inc R14
    inc R13
    cmp R11, 8
    jl iteration_loop2
    xor R15, R15
    xor R11, R11
    cmp R13, 8
    jne a8
    vmovups ymmword ptr [array], ymm14
    jmp iteration_loop2
a8: cmp R13, 16
    jne a9
    vmovups ymmword ptr [array], ymm13
    jmp iteration_loop2
a9: cmp R13, 24
    jne a10
    vmovups ymmword ptr [array], ymm12
    jmp iteration_loop2
a10: cmp R13, 32
    jne a11
    vmovups ymmword ptr [array], ymm11
    jmp iteration_loop2
a11: cmp R13, 40
    jne a12
    vmovups ymmword ptr [array], ymm10
    jmp iteration_loop2
a12: cmp R13, 48
    jne a13
    vmovups ymmword ptr [array], ymm9
    jmp iteration_loop2
a13: cmp R13, 56
    jne a14
    vmovups ymmword ptr [array], ymm8
    jmp iteration_loop2

a14: 
    mov r14eq, R14
    xor R15, R15
    xor R11, R11
    xor R13, R13
    sub R8, 1
    cmp R8, 0
    je restloop
    jmp iteration_loop

restloop:
    cmp R9, 0
    je restloop2

    mov r9eq, R9
iteration_loop3:
    mov eax, [RCX+R14*4]
    mov [R12+R15*4], eax
    inc R11
    inc R15
    inc R14
    inc R13
    cmp R11, 8
    jl iteration_loop3
    xor R15, R15
    xor R11, R11
    cmp R13, 8
    jne a15
    vmovups ymm15, ymmword ptr [array]
    sub R9, 1
    cmp R9, 0
    je next
    jmp iteration_loop3
a15: cmp R13, 16
    jne a16
    vmovups ymm14, ymmword ptr [array]
    sub R9, 1
    cmp R9, 0
    je next
    jmp iteration_loop3
a16: cmp R13, 24
    jne a17
    vmovups ymm13, ymmword ptr [array]
    sub R9, 1
    cmp R9, 0
    je next
    jmp iteration_loop3
a17: cmp R13, 32
    jne a18
    vmovups ymm12, ymmword ptr [array]
    sub R9, 1
    cmp R9, 0
    je next
    jmp iteration_loop3
a18: cmp R13, 40
    jne a19
    vmovups ymm11, ymmword ptr [array]
    sub R9, 1
    cmp R9, 0
    je next
    jmp iteration_loop3
a19: cmp R13, 48
    jne a20
    vmovups ymm10, ymmword ptr [array]
    sub R9, 1
    cmp R9, 0
    je next
    jmp iteration_loop3
a20: vmovups ymm9, ymmword ptr [array]

next:
    
    mov R9, r9eq
    vmulps ymm15, ymm7, ymm15
    sub R9, 1
    cmp R9, 0
    je next2
    vmulps ymm14, ymm7, ymm14
    sub R9, 1
    cmp R9, 0
    je next2
    vmulps ymm13, ymm7, ymm13
    sub R9, 1
    cmp R9, 0
    je next2
    vmulps ymm12, ymm7, ymm12
    sub R9, 1
    cmp R9, 0
    je next2
    vmulps ymm11, ymm7, ymm11
    sub R9, 1
    cmp R9, 0
    je next2
    vmulps ymm10, ymm7, ymm10
    sub R9, 1
    cmp R9, 0
    je next2
    vmulps ymm9, ymm7, ymm9

next2:

    mov R9, r9eq

    vminps ymm15, ymm15, ymm6
    sub R9, 1
    cmp R9, 0
    je next3
    vminps ymm14, ymm14, ymm6
    sub R9, 1
    cmp R9, 0
    je next3
    vminps ymm13, ymm13, ymm6
    sub R9, 1
    cmp R9, 0
    je next3
    vminps ymm12, ymm12, ymm6
    sub R9, 1
    cmp R9, 0
    je next3
    vminps ymm11, ymm11, ymm6
    sub R9, 1
    cmp R9, 0
    je next3
    vminps ymm10, ymm10, ymm6
    sub R9, 1
    cmp R9, 0
    je next3
    vminps ymm9, ymm9, ymm6

next3:
    
    mov R9, r9eq
    mov R14, r14eq
    xor R11, R11
    xor R15, R15
    xor R13, R13

    vmovups ymmword ptr [array], ymm15
iteration_loop4:
    mov eax, [R12+R15*4]
    mov [RCX+R14*4], eax
    inc R11
    inc R15
    inc R14
    inc R13
    cmp R11, 8
    jl iteration_loop4
    sub R9, 1
    cmp R9, 0
    je restloop2
    xor R15, R15
    xor R11, R11
    cmp R13, 8
    jne a21
    vmovups ymmword ptr [array], ymm14
    jmp iteration_loop4
a21: cmp R13, 16
    jne a22
    vmovups ymmword ptr [array], ymm13
    jmp iteration_loop4
a22: cmp R13, 24
    jne a23
    vmovups ymmword ptr [array], ymm12
    jmp iteration_loop4
a23: cmp R13, 32
    jne a24
    vmovups ymmword ptr [array], ymm11
    jmp iteration_loop4
a24: cmp R13, 40
    jne a25
    vmovups ymmword ptr [array], ymm10
    jmp iteration_loop4
a25: cmp R13, 48
    jne a26
    vmovups ymmword ptr [array], ymm9
    jmp iteration_loop4
a26: 

restloop2:

    mov eax, [rsp + 40]
    cmp eax, 0
    je theend
    xor R11, R11
    xor R15, R15
    mov r14eq, R14

iteration_loop5:
    mov eax, [RCX+R14*4]
    mov [R12+R15*4], eax
    inc R11
    inc R15
    inc R14
    cmp R11, 4
    jl iteration_loop5
    vmovups ymm15, ymmword ptr [array]
    vmulps ymm15, ymm7, ymm15
    vminps ymm15, ymm15, ymm6
    mov R14, r14eq
    xor R11, R11
    xor R15, R15
    vmovups ymmword ptr [array], ymm15
iteration_loop6:
    mov eax, [R12+R15*4]
    mov [RCX+R14*4], eax
    inc R11
    inc R15
    inc R14
    cmp R11, 4
    jl iteration_loop6
theend:
   
    mov R15, r15eq
    ret

Saturation endp

end