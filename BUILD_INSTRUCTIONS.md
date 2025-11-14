# Instrukcja budowania i uruchamiania

## Wymagania

- **.NET 8.0 SDK** lub nowszy
- **Windows** (WPF działa tylko na Windows)
- **Visual Studio 2022** (zalecane) lub **Rider** lub **VS Code z rozszerzeniem C#**

## Budowanie projektu

### Metoda 1: Visual Studio
1. Otwórz plik `ja_training_szponcenie.sln` w Visual Studio
2. Kliknij **Build → Build Solution** (Ctrl+Shift+B)
3. Uruchom aplikację klawiszem **F5**

### Metoda 2: Linia komend
```bash
cd /home/user/ja_training_szponcenie
dotnet build
dotnet run --project ja_training_szponcenie/ja_training_szponcenie.csproj
```

## Uruchomienie

Po uruchomieniu aplikacji:
1. Zobaczysz główne okno z przyciskiem **"Otwórz Rekordy i Power Curve"**
2. Kliknij przycisk aby otworzyć widok Records i Power Curve
3. Przełączaj się między zakładkami:
   - **Power Curve** - krzywa mocy z wykresem
   - **Rekordy mocy** - kategorie rekordów mocy
   - **Rekordy tętna** - rekordy HR, RHR, HRV
   - **Inne rekordy** - dystans, przewyższenie, TSS, prędkość

## Struktura projektu

```
ja_training_szponcenie/
├── ja_training_szponcenie.sln          # Solution file
├── ja_training_szponcenie/
│   ├── ja_training_szponcenie.csproj   # Plik projektu
│   ├── App.xaml                        # Aplikacja WPF
│   ├── MainWindow.xaml                 # Główne okno (launcher)
│   ├── Models/
│   │   └── SampleData.cs               # Przykładowe dane
│   └── Views/
│       ├── RecordsPowerCurveView.xaml  # Widok Records i Power Curve
│       └── Controls/
│           ├── RecordDetailPanel.xaml  # Panel szczegółów rekordu
│           └── ChartSettingsDialog.xaml # Dialog ustawień wykresu
├── RECORDS_UI_README.md                # Dokumentacja widoku
└── BUILD_INSTRUCTIONS.md               # Ten plik
```

## Funkcjonalności UI (gotowe)

✅ **Layout i struktura**
- 4 zakładki (Power Curve, Rekordy mocy, Tętno, Inne)
- Responsywny design
- Scrollowalne sekcje

✅ **Komponenty**
- Przyciski toggle dla zakresu czasowego
- Placeholder wykresu Power Curve
- Tabele z rekordami
- Kafelki statystyk
- Panel boczny szczegółów
- Dialog ustawień

✅ **Stylizacja**
- Material Design inspired
- Kolory stref mocy
- Cienie i zaokrąglone rogi
- Badge dla nowych rekordów

## TODO - Wymagana implementacja

❌ **Biblioteka wykresów**
- Dodać LiveCharts2 lub OxyPlot
- Zastąpić placeholdery prawdziwymi wykresami
- Implementacja zoom, pan, hover

❌ **MVVM Pattern**
- ViewModels dla każdej zakładki
- Data binding
- Commands zamiast event handlers

❌ **Logika biznesowa**
- Obliczanie rekordów
- Filtrowanie i sortowanie
- Eksport CSV/PNG
- Nawigacja do treningów

## Rozwiązywanie problemów

### Błąd kompilacji: "namespace Views does not exist"
- Upewnij się, że wszystkie pliki są w projekcie
- Rebuild całej solution (Clean + Build)

### Błąd: "InitializeComponent does not exist"
- Sprawdź czy pliki .xaml mają poprawny Build Action: **Page**
- Rebuild projektu

### Okno nie wyświetla się poprawnie
- Sprawdź rozdzielczość ekranu (minimalna: 1200x768)
- Upewnij się, że używasz Windows

## Dalszy rozwój

1. **Dodaj bibliotekę wykresów**
   ```bash
   dotnet add package LiveChartsCore.SkiaSharpView.WPF
   ```

2. **Implementuj MVVM**
   ```bash
   dotnet add package CommunityToolkit.Mvvm
   ```

3. **Dodaj dependency injection**
   ```bash
   dotnet add package Microsoft.Extensions.DependencyInjection
   ```

## Pomoc

Jeśli napotkasz problemy:
1. Sprawdź `RECORDS_UI_README.md` dla szczegółów UI
2. Upewnij się, że masz zainstalowany .NET 8.0 SDK
3. Sprawdź, czy wszystkie pliki zostały poprawnie utworzone

---

**Wersja**: 1.0
**Data**: 14.11.2025
**Platforma**: WPF (.NET 8.0)
