using static Hanoi.Utilities;

namespace Hanoi
{

    public partial class Program
    {
        static int  movesToEnd; //remaining number of moves
        static bool czySpowalniac = true;
        static int  waitTime = 90;

        static Stack stosA;
        static Stack stosB;
        static Stack stosC;

        static int TotalMoves(int n)
        {
            if (n == 1)
                return 1;
            else
            {
                int wyn = TotalMoves(n - 1);
                wyn = 2 * wyn + 1;
                return wyn;
            }
        }

        static void Hanoi(int n, Stack Sk, Stack Dk, Stack Pos)
        //Parameters:
        //n -  number of disks
        //Sk - Skad / Source
        //Dk - Dokad / Destination
        //Pos - Pozycja Srodkowa / Position in the Middle (Auxiliary Position)
        {
            if (n > 0)
            {
                Hanoi(n - 1, Sk, Pos, Dk);  //now Pos is (temporary) Destination, Dk is auxiliary
                
                Poczekaj(waitTime);

                Sk.Przenies(Dk);

                movesToEnd--;

                gotoXY(0, 1);
                Console.Write("Pozostalo:           " + movesToEnd + "   ");
                gotoXY(0, 1);

                Hanoi(n - 1, Pos, Dk, Sk);
            }

            static void Poczekaj(int waitTime)
            {
                if (czySpowalniac)
                    Thread.Sleep(waitTime);
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;

            //Number od disks:
            int n = 8;
            
            movesToEnd = TotalMoves(n);
            Console.Write("Do wykonania ruchow: " + movesToEnd);
            gotoXY(0, 1);
            Console.Write("Pozostalo:           " + movesToEnd);
            czySpowalniac = true;
            waitTime = 500;
            //
            stosA = new Stack(kA);
            stosB = new Stack(kB);
            stosC = new Stack(kC);
            //Putting disks on 1st stack and initial drawing of the 1st stack;
            //the idx `i' of the for loop will be the disk's ID:
            for (int i = 0; i < n; i++)
            {
                stosA.PutDisk(i);
                stosA.PrintTopDisk(segment);
            }
            //
            gotoXY(kA, Wd+1); Console.Write('A');
            gotoXY(kB, Wd+1); Console.Write('B');
            gotoXY(kC, Wd+1); Console.Write('C');
            //
            gotoXY(0, Wd+3);
            Console.WriteLine("Towers of Hanoi");
            Console.WriteLine("press any key...");
            Console.ReadKey();
            gotoXY(0, Wd + 4);
            Console.WriteLine("                                        ");
            //
            Hanoi(n, stosA, stosC, stosB);
            //
            //odstep pod rysunkiem:
            gotoXY(kA, Wd + 5);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

/* ****************************************
 * wzorzec - moj stary proceduralny kod w Turbo Pascalu, 1989
program whanoi;
uses crt,dos;
  Type Stosy=(A,B,C);
  Const maxkr=20;
        kA=15; kB=40; kC=65;
        wd=20;
        szerpdst=24; (* musi byc parzysta *)
       czlon=220;
  Var n,i,movesToEnd,waitTime:integer;
      ch:char;
      sledz,spowalniac:boolean;
      Sytuacja:array[Stosy] of record
                                 ile:0..maxkr;
                                 disks:array[1..maxkr] of 1..maxkr
                               end;


  Procedure Spowalniacz(k:integer);
    var i:integer;
    Procedure spow(n:integer);
      var i:integer;
      Begin 
        for i:=1 to n do begin
          n:=n+1; 
          n:=n-1 
       end
      End;
    Begin
      for i:=1 to k do spow(i)
    End;

  Procedure f(n:integer; var wyn:integer);
    Begin
      if n=1 then wyn:=1
      else begin
        f(n-1,wyn);
        wyn:=2*wyn+1
      end;
    End;

  Procedure RysunekPocz(n:integer);
    var i,j,dlug,w:integer;
    Begin
      gotoxy(kA,wd+1); write('A');
      gotoxy(kB,wd+1); write('B');
      gotoxy(kC,wd+1); write('C');
      for i:=1 to n do begin
        w:=wd-(i-1);
        dlug:=szerpdst-2*(i-1);
        gotoxy(kA-(dlug div 2),w);
        for j:=1 to dlug do write(chr(czlon));
      end;
    End;

  Procedure Rysuj(gdzie:Stosy; dlug:integer; co:char);
    var w,k,i:integer;
    Begin
      Case gdzie of
        A:k:=kA;
        B:k:=kB;
        C:k:=kC
      end;
      w:=wd-Sytuacja[gdzie].ile+1;
      gotoxy(k-(dlug div 2),w);
      for i:=1 to dlug do write(co);
    End;

  Procedure Przenies(Sk,Dk:Stosy);
    var dlug,rob:integer;
    Begin
      if sledz then ch:=readkey;
      with Sytuacja[Sk] do rob:=disks[ile];
      dlug:=szerpdst-2*(rob-1);
      Rysuj(Sk,dlug,' ');
      with Sytuacja[Sk] do ile:=ile-1;
      with Sytuacja[Dk] do ile:=ile+1;
      Rysuj(Dk,dlug,chr(czlon));
      with Sytuacja[Dk] do disks[ile]:=rob;   (* ten co przyszedl na stos *)
    End;

 Procedure Hanoi(n:integer; Sk,Dk,Pos:Stosy);
   Begin
     if n>0 then begin
       Hanoi(n-1,Sk,Pos,Dk);
       if spowalniac then Spowalniacz(waitTime);
       Przenies(Sk,Dk);
       movesToEnd:=movesToEnd-1;
       gotoxy(60,23);write('    ');gotoxy(60,23);write(movesToEnd:4);
       Hanoi(n-1,Pos,Dk,Sk)
     end;
   End;

 Procedure DajLiczbe(var n:integer);
 (* W przypadkach niebezpiecznych procedura zwroci n=1 *)   
   var tab:array[1..2] of char;
       x  :integer;
   Begin (* DajLiczbe *)
     for x:=1 to 2 do read(tab[x]);
     if not (tab[1] in ['0'..'9']) then n:=1
     else begin
       n:=ord(tab[1])-48;
       if tab[2] in ['0'..'9'] then n:=10*n+ord(tab[2])-48
     end;
     if n=0 then n:=1;
   End;  (* DajLiczbe *)
 label tu;
 BEGIN
   ClrScr;   
   write('Ilosc krazkow (1-12):');
   DajLiczbe(n);
   if n>12 then n:=12;
   write('  Przyjeto wartosc :',n:2);
   (*write('Wzor rysunk :'); read(czlon);*)
   f(n,movesToEnd);
   gotoxy(1,2);writeln('Ilosc potrzebnych ruchow :   ',movesToEnd:4);
   write('Wlaczyc sledzenie ?(T/N):');ch:=readkey;write(ch);
   sledz:=(ch='t') or (ch='T');
   if not sledz then begin
     gotoxy(1,4);write('Spowalniac ?(T/N):'); ch:=readkey;write(ch);
     spowalniac:=(ch='t') or (ch='T');
     if spowalniac then begin 
       gotoxy(1,5);write('Spowalniacz (1-90):');
       {$I-}
 tu:   read(waitTime);
       if ioresult<>0 then begin
         gotoxy(20,5);
         write('   ');
         gotoxy(20,5);
         goto tu
       end;
       {$I+}
       if waitTime>90 then waitTime:=90;
       write('Przyjeto liczbe :',waitTime:2);
       waitTime:=waitTime*10;
     end
   end;
   RysunekPocz(n);
   gotoxy(30,23);write('Do wykonania zostalo ruchow :');
   gotoxy(60,23);write(movesToEnd:4);
   with Sytuacja[A] do begin
     ile:=n;
     for i:=1 to n do disks[i]:=i;
   end;
   Sytuacja[B].ile:=0; sytuacja[C].ile:=0;
   Hanoi(n,A,C,B)
 END.
                                                                                                                            
*/
