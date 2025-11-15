# 📅 Widok Dnia (Day View) - Aplikacja Treningowa

Aplikacja WPF do zarządzania i wizualizacji danych treningowych, snu, żywienia i zdrowia.

## 📋 Struktura Projektu

```
ja_training_szponcenie/
├── Models/                      # Modele danych
│   ├── DayType.cs              # Enum typu dnia
│   ├── TrainingZone.cs         # Enum stref treningowych
│   ├── SleepPhase.cs           # Enum faz snu
│   ├── DayOverview.cs          # Podsumowanie dnia
│   ├── Training.cs             # Dane treningu
│   ├── Sleep.cs                # Dane snu
│   ├── Nutrition.cs            # Dane żywienia
│   ├── HeartRate.cs            # Dane tętna
│   ├── AdditionalMetrics.cs    # Dodatkowe metryki
│   ├── DayNotes.cs             # Notatki dnia
│   └── DayData.cs              # Główny model danych dnia
│
├── ViewModels/                  # ViewModels (MVVM)
│   ├── ViewModelBase.cs        # Bazowa klasa ViewModel
│   ├── RelayCommand.cs         # Implementacja ICommand
│   └── DayViewModel.cs         # ViewModel dla widoku dnia
│
├── Views/                       # Widoki XAML
│   └── DayView/
│       ├── DayView.xaml        # Główny widok dnia
│       └── DayView.xaml.cs     # Code-behind
│
├── Converters/                  # Konwertery XAML
│   ├── PercentToWidthConverter.cs
│   ├── ScoreToColorConverter.cs
│   ├── DayTypeToBrushConverter.cs
│   ├── DayTypeToTextConverter.cs
│   ├── TimeSpanToStringConverter.cs
│   └── BooleanToVisibilityConverter.cs
│
├── Resources/                   # Zasoby
│   └── Styles/
│       ├── Colors.xaml         # Definicje kolorów
│       └── Styles.xaml         # Style kontrolek
│
├── App.xaml                     # Konfiguracja aplikacji
├── App.xaml.cs
├── MainWindow.xaml              # Główne okno
└── MainWindow.xaml.cs
```

## 🎨 Sekcje Widoku Dnia

### 1. **Header (Nagłówek)**
- Przycisk powrotu (←)
- Tytuł: "Szczegóły dnia"
- Przycisk edycji notatek (✏️)
- Menu opcji (⋮)
- Nawigacja dni: ◀ Data ▶

### 2. **Podsumowanie Dnia (Overview Card)**
- Badge typu dnia (🏋️ Dzień treningowy, 😴 Odpoczynek, 🏆 Wyścig, ⚠️ Uwaga)
- Ogólna ocena dnia: 82/100
- Quick metrics:
  - TSS: 124
  - Czas treningu: 1h 45min
  - Kalorie: 2680 kcal 🍽️
  - Sen: 7h 30min 😴 (Score: 88/100)
  - HRV: 68ms ❤️
- Pasek gotowości do treningu

### 3. **Treningi 🚴**
- Lista treningów z możliwością rozwijania
- Godzina, nazwa, typ (indoor/outdoor)
- Szybkie metryki: czas, dystans, moc, TSS
- Pasek stref treningowych (kolorowy)
- Po rozwinięciu: szczegółowe metryki (NP, IF, Work, przewyższenie)

### 4. **Sen 😴**
- Sleep Score: 88/100
- Całkowity czas snu: 7h 30min
- Godziny: 22:45 - 6:15
- Efektywność snu: 94%
- **Fazy snu** (z paskami postępu):
  - Sen głęboki: 1h 52min (25%)
  - Sen REM: 1h 41min (22%)
  - Sen lekki: 3h 45min (50%)
  - Czuwanie: 12min (3%)
- **Metryki fizjologiczne**:
  - Tętno spoczynkowe: 47 bpm
  - HRV poranne: 68ms
  - Temperatura: ↓ 0.6°C
  - Oddech: 14/min
- Ocena algorytmu: "✅ Doskonała regeneracja"

### 5. **Żywienie 🍽️**
- Pierścień kaloryczny: 2680 / 3000 kcal
- **Makroskładniki** (z paskami):
  - 🥩 Białko: 145g / 160g (91%)
  - 🍞 Węglowodany: 312g / 350g (89%)
  - 🥑 Tłuszcze: 78g / 90g (87%)
- **Bilans energetyczny**:
  - BMR: 1850 kcal
  - Trening: 370 kcal
  - Aktywność: 280 kcal
  - Bilans: -320 kcal

### 6. **Tętno przez dzień ❤️**
- Wykres tętna 24h (placeholder)
- **Metryki**:
  - RHR: 47 bpm (▼ -4 bpm)
  - Średnie dzienne: 72 bpm
  - Maksymalne: 182 bpm
  - HRV poranne: 68ms (▲ +6ms)

### 7. **Dodatkowe Metryki 📊** (rozwijane)
- 👟 Kroki: 8,450 / 10,000
- Aktywność: 2h 15min (280 kcal)
- Poziom stresu: 35/100
- Saturacja (SpO2): 97%
- Temperatura: 36.6°C

### 8. **Notatki i Obserwacje 📝**
- Pole tekstowe do notatek
- Wybór nastroju: 😃 😊 😐 😕 😫
- **Tagi**:
  - ✅ Dobry sen
  - 💪 Świetna forma
  - 😴 Zmęczenie
  - 🤒 Choroba
  - 😰 Stres
  - 🌧️ Zła pogoda
  - 🔥 Ciężki trening

### 9. **Przyciski Akcji**
- 📊 Porównaj z innym dniem
- 📤 Eksportuj raport dnia

## 🎨 Kolorystyka

### Sekcje
- **Trening**: Niebieski (#2196F3)
- **Sen**: Fioletowy (#9C27B0)
- **Żywienie**: Zielony (#4CAF50)
- **Tętno**: Czerwony (#F44336)

### Statusy
- **Dobry/Świetny**: Zielony (#4CAF50)
- **Przeciętny**: Żółty (#FFC107)
- **Słaby**: Czerwony (#F44336)

### Strefy Treningowe
- **Z1**: Szary (#B0BEC5)
- **Z2**: Niebieski (#64B5F6)
- **Z3**: Zielony (#4CAF50)
- **Z4**: Żółty (#FFC107)
- **Z5**: Czerwony (#F44336)

### Fazy Snu
- **Głęboki**: Ciemny niebieski (#1A237E)
- **REM**: Fioletowy (#9C27B0)
- **Lekki**: Jasny niebieski (#64B5F6)
- **Czuwanie**: Szary (#9E9E9E)

## 🔧 Funkcjonalności

### Nawigacja
- Swipe w lewo → następny dzień
- Swipe w prawo → poprzedni dzień
- Przyciski ◀ / ▶ dla zmiany dnia
- Przycisk ← powrót do dashboardu

### Interakcje
- Kliknięcie sekcji treningu → szczegółowa analiza
- Kliknięcie sekcji snu → pełny widok snu z trendami
- Kliknięcie sekcji żywienia → szczegóły posiłków
- Rozwijanie/zwijanie dodatkowych metryk
- Edycja notatek inline

### Dane Przykładowe
DayViewModel zawiera metodę `LoadSampleData()` która ładuje przykładowe dane dla prezentacji.

## 📱 Responsywność

### Szerokie ekrany (>1200px)
- Treningi i Sen obok siebie (2 kolumny)
- Żywienie i Tętno obok siebie

### Średnie (800-1200px)
- Wszystko w jednej kolumnie
- Większe karty

### Wąskie (<800px)
- Jedna kolumna
- Kompaktowe widoki

## 🚀 Technologie

- **.NET 8.0**
- **WPF (Windows Presentation Foundation)**
- **MVVM Pattern**
- **Data Binding**
- **Converters**
- **Styles & Templates**

## 📐 Layout

### Padding & Margins
- Boczny padding: 16-20px
- Między sekcjami: 24px
- Wewnątrz kart: 16px

### Wysokości Sekcji
- Header: 60-80px
- Podsumowanie: 150-200px
- Sen: 300-400px
- Żywienie: 350-450px
- Tętno: 300-350px
- Dodatkowe metryki: 200-400px
- Notatki: 200-300px

## 📝 Notatki Implementacyjne

1. **Wykresy** - Obecnie placeholdery, można zaimplementować używając:
   - OxyPlot
   - LiveCharts
   - ScottPlot

2. **Pierścień kaloryczny** - Uproszczona wersja z Ellipse, dla prawdziwego pierścienia użyć Arc lub Path z geometrią

3. **Expandable Cards** - Obecnie Visibility="Collapsed", można dodać animacje z DoubleAnimation

4. **Swipe Gestures** - Wymaga dodania TouchGesture lub ManipulationDelta handlers

5. **Export/Compare** - Funkcje TODO w DayViewModel

## 🔮 Przyszłe Rozszerzenia

- [ ] Implementacja wykresów (tętno 24h, fazy snu)
- [ ] Animacje rozwijania/zwijania sekcji
- [ ] Swipe gestures dla nawigacji
- [ ] Export do PDF/CSV
- [ ] Porównywanie dni
- [ ] Integracja z bazą danych
- [ ] Synchronizacja z urządzeniami (Garmin, Fitatu)
- [ ] Widok kalendarza pełnoekranowego
- [ ] Dashboard z przeglądem tygodnia/miesiąca

## 👨‍💻 Autor

Projekt stworzony jako część systemu treningowego dla sportowców.
