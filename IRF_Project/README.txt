Neptun kód: CCUUQW
Feladat:
Adatimportálás: B (adatbázis létrehozása)
Adatfeldolgozás: D (Unit Test megvalósítása)
Adatexportálás: A (írás CSV fájlba)
Általános elemek: E (Graphics osztály használata)

A feladatomhoz egy döntést segítő programot hozok létre egy Forma-1-es csapatfőnök
számára. A főnök ennek a programnak a segítségével tudja eldönteni, melyik pilótát 
válassza ki csapata számára. Ahhoz, hogy egy pilóta a Forma-1-be kerüljön, egy
úgynevezett 'Szuperlicenszre' van szüksége, amit az FIA (Nemzetközi Automobil 
Szövetség) által lehet kiváltani. A Szuperlicensz egyik feltétele, hogy a pilóta 
legalább 18 éves legyen, a másik, hogy a kisebb, utánpótlás sorozatokban elért 
eredményeivel a pilóta legalább 40 'Szuperlicensz pontot' szerezzen. Az adatbázisban
az F2, F3, GP3, és az FE sorozatok pilótáit tartalmazza, realisztikusan rajtuk 
kívül nincs sok esélye egy pilótának a Forma-1-be kerülésre. Az adatbázisom első
adattáblájának oszlopai:

név: a pilóta neve
nem: a pilóta neme (1: férfi, 0: nő)
kor: a pilóta életkora (elegánsabb lenne születési dátummal megoldani, de a feladathoz 
			nem akartam ezzel vacakolni; megj: az egyik versenyző a táblából
			már sajnos elhunyt, de a teljesség kedvéért az eredményei miatt
			bennehagytam a nevét, viszont a korát 0-nak adtam meg, hogy
			ne ajánlja a program semmilyen körülmények közt)
18f2-20fe (xxyy): a pilóta helyezése a 20xx évben az yy sorozatban
egyéb: vannak pilóták, akik további sorozatokban elért eredményükkel elérik a 40 szuper-
	licensz pontot; náluk az egyéb értéke 1, másoknál 0
szerződés: a pilóta F1-es versenyzői szerződéssel rendelkezik 2021-re (1: igen, 0: nem);
		ilyen pilótával már nem foglalkozik a csapat
verseny: a pilóta korábban már versenyzett a Forma-1-ben (1: igen, 0: nem)
teszt: a pilóta korábban már tesztelt Forma-1-es autóval (1: igen, 0: nem)

Olyan tulajdonságokat próbáltam választani, amik mérvadóak és objektíven meghatározhatók
egy pilótáról. Vannak még egyéb tényezők is (pl. tehetség, anyagi támogatás, népszerűség)
amiket nem tudtam belevenni, ezeket majd a csapatfőnöknek magának kell eldöntenie, 
mennyire számít a pilótaválasztásnál.

Háromféle szerepkörre lehet pilótát választani:
- versenyző: egy csapatnak 2 pilótája van, és 10 csapat van a mezőnyben, így ide csak
		a legjobbak kerülhetnek, megfelelő korban, legalább 40 szuperlicensz
		ponttal
- tesztpilóta: a csapat egy tesztpilóta segítségével tudja az autóját fejleszteni, 
		erre egy tehetségesebb fiatal, vagy egy tapasztalt idősebb pilóta
		alkalmas; egy csapat általában 1-3 pilótát alkalmaz, szélesebb
		választékból kerülhetnek ki, szuperlicensz nem szükséges, de legyenek
		eredményei
- junior: a jövő tehetsége, aki legfeljebb 20 éves; egyelőre még nincs a Forma-1
		szintjén, vannak ígéretes eredményei, de szuperlicensze még nincs, 
		pár éven belül a csapat megfelelő szintre nevelheti

Megjegyzés: az adatbázist csak a megadott sorozatokban az elmúlt 3 évben versenyző 
	pilótákkal töltöttem fel, ennél természetesen sokkal több pilóta közül választ
	egy csapat, és egyéb utánpótlás sorozatokban (amikből még több 10 van) szerzett
	pontokat nem, vagy csak részlegesen vettem figyelembe. Valós döntéshez ehhez 
	sokkal jobban feltöltött adattábla kellhet, de ehhez a feladathoz túlzás lett 
	volna. Emellett az FE (elektromos forma-autós bajnokság) nem utánpótlás nevelő 
	sorozat, viszont tapasztalt pilóták vannak itt is, akik akár versenyzői, vagy
	tesztpilótai szerepre még alkalmasak lehetnek a Forma-1-ben. Ezen pilóták közül
	sokaknak még korábbi F1-es szereplésük miatt érvényes szuperlicensze is van, 
	viszont ez nincsen elérhetően nyilvántartva, így ezt nem tudtam hozzáadni az
	adatbázishoz.

A második adattáblában szerepel az egyes sorozatban elért helyezések után járó 
szuperlicensz pontok száma. Egyértelmű, hogy a legnagyobb rangja a F2-nek van, ugyanis
ott még a bajnoki 3. helyezett is azonnal eléri a szükséges 40 pontot, viszont a többi
sorozatban még egyszeri bajnoki cím sem elég. A különböző sorozatokban elért pontszámok
összeadódnak az elmúlt három évből.
(sok egyéb részlete van a szuperlicensznek, amik egy ilyen feladathoz nem részletesek,
itt lehet olvasni róla: https://en.wikipedia.org/wiki/FIA_Super_Licence)