# IRF_Project
IRF házi feladat
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

id
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
mennyire számít a pilótaválasztásnál. A különböző tényezők viszont súlyozva vannak.

A második adattáblában szerepel az egyes sorozatban elért helyezések után járó 
szuperlicensz pontok száma. Egyértelmű, hogy a legnagyobb rangja a F2-nek van, ugyanis
ott még a bajnoki 3. helyezett is azonnal eléri a szükséges 40 pontot, viszont a többi
sorozatban még egyszeri bajnoki cím sem elég. A különböző sorozatokban elért pontszámok
összeadódnak az elmúlt három évből.
(sok egyéb részlete van a szuperlicensznek, amik egy ilyen feladathoz nem részletesek,
itt lehet olvasni róla: https://en.wikipedia.org/wiki/FIA_Super_Licence)

Létrehozott osztályok:
- Pilota: tartalmazza a pilóta nevét, nemét (1=férfi, 0=nő), korát, pontszámát (a kötött
	adattáblákban lévő értékek alapján összegezve), F1-es szerződését (1=van,
	0=nincs), F1-es versenymúltját (1=van, 0=nincs), F1-es tesztmúltját (1=van,
	0=nincs). Tartalmaz a teszteléshez egy ValidatePilota bool függvényt, ami
	meghatározza, hogy van-e értelme tovább foglalkozni a pilótával (akkor false,
	ha nincs legjobb 15-beli eredménye a pilótának, vagy már van szerződése valahol).
- Szorzok: A Pilota tulajdonságai alapján különböző szorzókat rendeltem egy pilótához,
	az osztály tartalmazza a pilóta nevét, neméhez tartozó szorzót (férfi: 1, nő: 1.2;
	kevés a női pilóta, így a marketing értéke magasabb), korához tartozó szorzót
	(18 év alatt 1.5, 18-20 között 1.3, 21-24 között 1, 25-31 között 0.8, 32-35 
	között 0.5, 36 felett 0.2), tapasztalatához tartozó szorzót(versenyzett már F1-ben:
	1.5, tesztelt már F1-ben: 1.3, különben 1), és a szuperlicensz pontszámát.
- Kategoria: Tartalmazza a nevet, az értékelést ((1+pontszám)*szorzók), ajánlott-e
	versenyzőnek, ajánlott-e tesztpilótának, ajánlott-e juniornak.

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

A PROGRAM MŰKÖDÉSE
Az osztályoknál felsorolt értékeket a programban, függvényekben rendeltem hozzá a 
pilótákhoz. A először az adatbázisból beolvastam az összes pilótát a pilots listába 
(Pilot típus), majd a Feltoltes függvényben a pilotak listába (Pilota típus) azok a 
versenyzők kerültek csak az osztálynál leírtak szerint, akikkel még van értelme
foglalkozni. Ezután az Osztalyozas függvényben a szorzok listát töltöttem fel (Szorzok
típus), majd a Kategorizal függvényben jöttek a döntések, hogy kit milyen kategóriába
érdemes besorolni, ezt a kategoriak Kategoria típusú listába töltöttem fel azokkal, 
akik legalább az egyik katergóriába bekerültek. Az itt kapott Ertekeles pontszám
általam kitalált, viszont a puszta szuperlicensz pontszámon túl segít a döntés-
hozásban. Ezután a Rendezes függvényben az Ertekeles alapján sorba rendeztem a 
versenyzőket a rendezett listába (szintén Kategoria típus), amit talán LINQ-val
is meg lehetett volna oldani, viszont ez megkönnyíti utána az adatok további elemzését,
amikor az értékeket csv fájlba kimentem (button4-hez tartozó eseménykezelőben).
A mentés gombon kívül a formon három gomb van, az egyes kategoriákhoz tartozóan.
Az adott gomb megnyomására megjelenik, hogy ki a legjobb jelölt az egyes kategoriára,
figyelembe azt, hogy tesztpilótának minden pilóta jelölt, aki versenyzőnek is jelölt,
így itt csak olyanok szerepelnek, akik nem jelöltek versenyzőnek; ezt LINQ lekérdezéssel
valósítom meg. A feladat a Graphics osztály használatát is elvárta, így illusztrálásként
egy fényképet tettem be a három kategória jelöltjéről, és ezekre rajzoltam rá egy-egy 
lufit (elipszisből és 4 vonalból). Egy kicsit egyszerűsítettem a saját dolgomon, ugyanis
csak azokról tettem képet a projektbe, akikről tudtam, hogy a jelöltek lesznek, viszont
ID/név alapján könnyen lehetne kiterjeszteni mindenkire, idő hiányában nem töltöttem le
140+ képet.

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
