# Records i Power Curve - Widok UI (WPF)

## Opis
Pełny widok interfejsu użytkownika dla funkcjonalności "Rekordy i Power Curve" w aplikacji treningowej.
**Uwaga:** To jest tylko warstwa wizualna (UI) bez logiki biznesowej - zawiera przykładowe dane hardcoded.

## Struktura plików

### Główne widoki
- **`Views/RecordsPowerCurveView.xaml`** - Główne okno z 4 zakładkami:
  - Power Curve (krzywa mocy z wykresem)
  - Rekordy mocy (kategorie rekordów)
  - Rekordy tętna (HR, RHR, HRV)
  - Inne rekordy (dystans, przewyższenie, TSS, prędkość, kadencja)

### Kontrolki pomocnicze
- **`Views/Controls/RecordDetailPanel.xaml`** - Panel boczny z szczegółami wybranego rekordu
  - Podstawowe informacje (moc, W/kg, % FTP, strefa)
  - Status rekordu (nowy/obecny)
  - Szczegóły treningu
  - Kontekst (warunki, tętno, kadencja)
  - Wykres fragmentu
  - Historia rekordu
  - Top 3 wyniki

- **`Views/Controls/ChartSettingsDialog.xaml`** - Dialog ustawień wykresu
  - Wygląd (szerokość linii, rozmiar punktów, przezroczystość)
  - Kolory (linia główna, porównawcza, tło, siatka)
  - Punkty czasowe (wybór czasów do wyświetlenia)

### Modele danych (przykładowe)
- **`Models/SampleData.cs`** - Przykładowe dane do wyświetlenia w UI
  - PowerCurvePoint (punkty krzywej mocy)
  - HeartRateRecord (rekordy tętna)
  - OtherRecord (inne rekordy)

## Główne funkcje UI

### Zakładka 1: Power Curve
✅ **Sekcja wyboru zakresu czasowego**
- Przyciski: Ostatnie 30/90 dni, 6 miesięcy, rok, cały czas, niestandardowy
- Informacja o okresie i liczbie treningów

✅ **Główny wykres Power Curve**
- Wykres liniowy z logarytmiczną skalą X
- Punkty: 5s do 120min
- Linie: rekordy osobiste, okresy porównawcze, FTP, model Critical Power
- Toolbar: checkboxy (punkty, FTP, W/kg), zoom, reset
- Kolory punktów według statusu (nowy/top/standardowy)

✅ **Porównanie okresów**
- Dodawanie do 3 okresów porównawczych
- Color picker dla każdego okresu
- Toggle włącz/wyłącz na wykresie

✅ **Tabela rekordów**
- Kolumny: Czas, Moc, W/kg, % FTP, Data, Trening, Status, Akcje
- Kolorowanie według stref mocy
- Badge dla nowych rekordów
- Zebra striping
- Sortowanie i filtrowanie

### Zakładka 2: Rekordy mocy
✅ **Statystyki ogólne** (4 kafelki)
- Wszystkie rekordy mocy
- Ostatni rekord
- Najwyższy 20min
- Średnia progresja

✅ **Kategorie rekordów** (Expander/Accordion)
- ⚡ Sprinty (<1 min)
- 🔥 Krótkie interwały (1-5 min)
- 💪 Średnie interwały (5-20 min)
- 🚴 Długie wysiłki (>20 min)

✅ **Filtry i sortowanie**
- Dropdown: okres czasu
- Checkboxy: tylko nowe, tylko >100% FTP
- Wyszukiwanie po nazwie

### Zakładka 3: Rekordy tętna
✅ **Statystyki ogólne** (4 kafelki)
- Max HR
- Najniższe RHR
- Najwyższe HRV
- Średnie RHR (90d)

✅ **Wykres trendu**
- Wybór: RHR / HRV / Max HR
- Linia trendu z zaznaczonymi obszarami

✅ **Kategorie** (Expander)
- ❤️ Maksymalne wartości tętna
- 💤 Rekordy tętna spoczynkowego
- 📊 Rekordy HRV
- 🎯 Strefy tętna

### Zakładka 4: Inne rekordy
✅ **Kategorie** (Expander)
- 📏 Rekordy dystansu
- ⛰️ Rekordy przewyższenia
- 💪 Rekordy TSS i obciążenia
- 🏃 Rekordy prędkości
- 🔄 Rekordy kadencji
- ⚡ Rekordy wydajności

## Stylizacja

### Kolory główne
- Primary (niebieski): `#2196F3`
- Sukces (zielony): `#4CAF50`
- Ostrzeżenie (pomarańczowy): `#FF9800`
- Błąd (czerwony): `#F44336`
- Tło: `#F5F5F5`
- Białe karty: `#FFFFFF`

### Strefy mocy (kolory)
- >160% FTP: `#B71C1C` (ciemny czerwony)
- 120-160%: `#D32F2F` (czerwony)
- 100-120%: `#F57C00` (pomarańczowy)
- 85-100%: `#FFB300` (żółty)
- <85%: `#4CAF50` (zielony)

### Efekty
- Cienie (DropShadow): blur 10px, głębokość 2px, opacity 0.2
- Zaokrąglone rogi: 4-8px
- Hover: podświetlenie, zmiana kursora

## Funkcje interaktywne (UI only)

### Wykres Power Curve
- ❌ Zoom (scroll, zaznaczenie obszaru) - **wymaga implementacji**
- ❌ Pan (przesuwanie) - **wymaga implementacji**
- ❌ Hover nad punktem (tooltip, linie pomocnicze) - **wymaga implementacji**
- ✅ Kliknięcie w punkt → panel szczegółów (statyczny layout gotowy)

### Tabela
- ✅ Hover wiersza (podświetlenie)
- ❌ Kliknięcie → panel szczegółów - **wymaga implementacji**
- ❌ Link do treningu - **wymaga implementacji**

### Przyciski akcji
- ❌ Eksport do CSV - **wymaga implementacji**
- ❌ Eksport wykresu PNG - **wymaga implementacji**
- ❌ Zobacz trening - **wymaga implementacji**
- ❌ Udostępnij - **wymaga implementacji**

## Jak użyć

### Otwarcie widoku
```csharp
var window = new RecordsPowerCurveView();
window.ShowDialog();
```

### Otwarcie dialogu ustawień
```csharp
var dialog = new ChartSettingsDialog();
dialog.Owner = this;
dialog.ShowDialog();
```

### Panel szczegółów
Panel szczegółów (`RecordDetailPanel`) może być użyty jako:
- UserControl w głównym widoku (wysuwany z prawej strony)
- Osobne okno/dialog
- Część layout grid

## Responsywność

Widok został zaprojektowany dla rozdzielczości:
- **Optymalna**: 1600x900 px i więcej
- **Minimalna**: 1200x768 px

### Zalecenia na mniejsze ekrany
- Użyj ScrollViewer dla wszystkich sekcji
- Tabele z HorizontalScrollBarVisibility="Auto"
- Panel szczegółów jako osobne okno zamiast bocznego panelu

## TODO - Wymagana implementacja

### 1. Biblioteka wykresów
Aby wykresy działały poprawnie, należy dodać bibliotekę np.:
- **LiveCharts2** (WPF) - https://lvcharts.com/
- **OxyPlot** (WPF) - https://oxyplot.github.io/
- **SciChart** (komercyjny)

### 2. Data binding
- Utworzenie ViewModels (MVVM)
- Bindowanie danych z `SampleData` do kontrolek
- INotifyPropertyChanged dla reaktywności

### 3. Logika biznesowa
- Obliczanie rekordów z treningów
- Filtrowanie i sortowanie danych
- Porównywanie okresów
- Eksport danych (CSV, PNG)

### 4. Interakcje
- Obsługa kliknięć w punkty wykresu
- Zoom i pan wykresu
- Nawigacja do treningu
- Color pickery dla okresów

### 5. Animacje
- Płynne przejścia między zakładkami
- Animacja wysuwania panelu szczegółów
- Animacje wykresów (fade in/out)

## Struktura folderów

```
ja_training_szponcenie/
├── Models/
│   └── SampleData.cs              # Przykładowe dane
├── Views/
│   ├── RecordsPowerCurveView.xaml # Główny widok
│   ├── RecordsPowerCurveView.xaml.cs
│   └── Controls/
│       ├── RecordDetailPanel.xaml # Panel szczegółów
│       ├── RecordDetailPanel.xaml.cs
│       ├── ChartSettingsDialog.xaml # Dialog ustawień
│       └── ChartSettingsDialog.xaml.cs
└── RECORDS_UI_README.md           # Ten plik
```

## Notatki rozwojowe

### Potencjalne ulepszenia
1. **Analiza progresji** - wykres jak zmieniały się rekordy w czasie
2. **Prognoza AI** - przewidywanie przyszłych rekordów
3. **Porównanie z innymi użytkownikami** - ranking
4. **Integracja z urządzeniami** - import z Garmin/Strava
5. **Eksport raportów PDF** - profesjonalne raporty
6. **Udostępnianie social media** - automatyczne grafiki

### Znane ograniczenia (tylko UI)
- Brak rzeczywistego wykresu (placeholder Canvas)
- Brak data binding
- Statyczne dane przykładowe
- Brak obsługi błędów
- Brak walidacji

---

**Wersja**: 1.0 (UI only)
**Data**: 14.11.2025
**Autor**: Claude Code
**Licencja**: Według projektu głównego
