# JA Training - Dashboard UI

Aplikacja WPF do zarządzania treningami, śledzenia wydolności i monitorowania zdrowia dla sportowców.

## Opis

JA Training to zaawansowana aplikacja desktopowa stworzona w technologii WPF (.NET 8.0), która umożliwia sportowcom (szczególnie kolarzom) śledzenie:
- Formy treningowej (Performance Management Chart - PMC)
- Treningów i kalendarza
- Snu i regeneracji
- Żywienia
- Wellness i gotowości do treningu
- Rekordów osobistych

## Struktura projektu

```
ja_training_szponcenie/
├── Views/
│   ├── DashboardView.xaml          # Główny widok dashboardu
│   ├── DashboardView.xaml.cs       # Code-behind dla dashboardu
│   ├── NavigationDrawer.xaml       # Boczne menu nawigacyjne
│   └── NavigationDrawer.xaml.cs    # Code-behind dla menu
├── Resources/
│   └── Styles/
│       └── Styles.xaml             # Globalne style i kolory
├── App.xaml                         # Konfiguracja aplikacji
├── App.xaml.cs
├── MainWindow.xaml                  # Główne okno aplikacji
└── MainWindow.xaml.cs
```

## Komponenty Dashboard

### 1. Header (Nagłówek)
- **Lewa strona**: Logo aplikacji "JA Training" i przycisk menu hamburger (☰)
- **Środek**: Tytuł "Dashboard" i aktualna data
- **Prawa strona**: Ikona ustawień (⚙️) i zdjęcie profilowe użytkownika

### 2. Performance Management Chart (PMC)
Sekcja "Forma treningowa" zawierająca:
- **Trzy kafelki metryk**:
  - **Fitness (CTL)**: Chronic Training Load - długoterminowe obciążenie treningowe (kolor niebieski)
  - **Fatigue (ATL)**: Acute Training Load - krótkoterminowe zmęczenie (kolor pomarańczowy)
  - **Form (TSB)**: Training Stress Balance - balans między formą a zmęczeniem (kolor zielony/czerwony)
- **Wykres liniowy**: Wizualizacja zmian CTL, ATL i TSB w czasie (6-12 tygodni)
- **Przycisk ustawień**: Konfiguracja wykresu (przedział czasu, widoczność linii)

### 3. Kalendarz treningowy
- **Nawigacja miesiąca**: Strzałki do przełączania między miesiącami i przycisk "Dzisiaj"
- **Siatka kalendarza**:
  - 7 kolumn (Pn-Nd)
  - Każdy dzień zawiera:
    - Numer dnia i badge statusu (🏋️ trening, 😴 odpoczynek, 🏆 wyścig)
    - Informacje o treningu (czas, TSS)
    - Dane o śnie (czas, jakość - kolorowe tło)
    - Status wellness
  - Dzisiejsza data wyróżniona niebieskim obramowaniem
- **Podsumowania tygodni** (prawa strona):
  - Lista tygodni z metrykami (TSS, liczba treningów, czas, dystans)
  - Średni sleep score, bilans kaloryczny, HRV
  - Wizualizacja tygodnia słupkami

### 4. Quick Stats (Szybkie statystyki)
Poziomy rzęd przewijalnych kafelków:
- **Ten miesiąc**: Liczba treningów, całkowity TSS, średni sleep score
- **Bieżący tydzień**: Treningi, TSS, HRV, bilans kaloryczny
- **FTP**: Aktualne wartości FTP (W i W/kg), data ostatniego testu
- **Wellness**: Gotowość do treningu (0-100), status formy

### 5. Rekordy osobiste
- Lista 3 ostatnich/najważniejszych rekordów mocy
- Ikona 🆕 przy nowych rekordach (ostatnie 7 dni)
- Przycisk "Zobacz wszystkie >" do pełnego widoku

### 6. Floating Action Button (FAB)
- Duży okrągły przycisk "+" w prawym dolnym rogu
- Zawsze widoczny podczas przewijania
- Służy do dodawania nowych treningów (import pliku FIT)

## Boczne Menu Nawigacyjne

### Struktura menu:

**GŁÓWNA**
- 🏠 Dashboard (aktualnie wybrany)
- 📅 Kalendarz
- ➕ Dodaj trening

**ANALIZA**
- 📋 Lista treningów
- 📈 Analiza treningu
- 📉 Power Curve
- 🏆 Rekordy osobiste

**ZDROWIE I REGENERACJA**
- 😴 Sen
- 🍽️ Żywienie
- ❤️ Tętno
- 💪 Wellness

**IMPORT DANYCH**
- 📁 Import żywienia (CSV z Fitatu)
- 📊 Import danych zdrowotnych (Mi Fit / inne źródła)

**INNE**
- ⚙️ Ustawienia
- ❓ Pomoc
- ℹ️ O aplikacji

## Kolory i Style

### Paleta kolorów:
- **Primary**: #2196F3 (niebieski)
- **Secondary**: #1976D2 (ciemny niebieski)
- **Accent**: #03A9F4 (jasny niebieski)
- **Background**: #F5F5F5 (jasny szary)
- **Surface**: #FFFFFF (biały)

### Kolory metryk:
- **Fitness**: #2196F3 (niebieski)
- **Fatigue**: #FF9800 (pomarańczowy)
- **Form pozytywna**: #4CAF50 (zielony)
- **Form negatywna**: #F44336 (czerwony)

### Kolory statusów:
- **Sukces**: #4CAF50 (zielony) - dobry sen, pozytywna forma
- **Ostrzeżenie**: #FFC107 (żółty) - średni sen, neutralna forma
- **Błąd**: #F44336 (czerwony) - słaby sen, negatywna forma

## Uruchamianie aplikacji

### Wymagania:
- .NET 8.0 SDK
- Windows 10/11
- Visual Studio 2022 lub JetBrains Rider (opcjonalnie)

### Kompilacja i uruchomienie:

```bash
# Przejdź do katalogu projektu
cd ja_training_szponcenie

# Zbuduj projekt
dotnet build

# Uruchom aplikację
dotnet run
```

### Visual Studio:
1. Otwórz plik `ja_training_szponcenie.sln`
2. Naciśnij F5 lub kliknij "Start"

## Uwagi implementacyjne

### Aktualna implementacja:
- ✅ Kompletna struktura UI w XAML
- ✅ Stylizacja i kolory
- ✅ Layout responsywny
- ✅ Przykładowe dane statyczne

### Do implementacji (logika):
- ❌ Obsługa zdarzeń (kliknięcia przycisków)
- ❌ Bindowanie danych (MVVM pattern)
- ❌ Nawigacja między widokami
- ❌ Import plików FIT
- ❌ Baza danych
- ❌ Wykresy (rekomendowane: LiveCharts2 lub OxyPlot)
- ❌ Animacje menu wysuwnego

## Rozszerzenia do rozważenia

1. **Biblioteki do wykresów**:
   - LiveCharts2 - nowoczesne, responsywne wykresy
   - OxyPlot - zaawansowane wykresy naukowe
   - ScottPlot - szybkie wykresy do dużych zestawów danych

2. **MVVM Framework**:
   - CommunityToolkit.Mvvm
   - Prism
   - ReactiveUI

3. **Baza danych**:
   - SQLite (lekka, lokalna)
   - Entity Framework Core

4. **Import plików**:
   - FIT SDK (Garmin) do importu plików treningowych
   - TCX/GPX parsery

## Licencja

Projekt jest częścią JA Training Team.

## Kontakt

Dla pytań i sugestii, skontaktuj się z zespołem JA Training.
