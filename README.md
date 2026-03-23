# BubbleTier

Console app che genera una sequenza di numeri casuali, la ordina con bubble sort e mostra a schermo sia i dati originali sia quelli ordinati. La struttura è separata a livelli: repository, service e controller, con `Program` come entry point.

## Struttura e interazione
```mermaid
flowchart TD
    Program[Presentation/Program.cs<br/>Entry point] --> Controller[Presentation/OrderedNumberController.cs<br/>Presentation]
    Controller --> Service[Business/BubbleSortService.cs<br/>Service layer]
    Service --> Repository[Repository/NumbersRepository.cs<br/>Repository]
    Service -->|Ordina| BubbleSort[BubbleSort()]
    Repository -->|GetAll()<br/>Numeri casuali| Service
    Service -->|Tupla ordered/unordered| Controller
    Controller -->|Risultato| Program
    Config[Config.cs<br/>Config] -.-> Program
    Config -.-> Service
```

## Dettaglio dei file

### `BubbleTier/Presentation/Program.cs`
- **Responsabilità**: entry point e composizione delle dipendenze.
- **Interazioni**:
  - Istanzia `NumbersRepository`, `BubbleSortService` e `OrderedNumberController`.
  - Chiama `GetOrderedNumbers()` sul controller e stampa i risultati.

### `BubbleTier/Presentation/OrderedNumberController.cs`
- **Responsabilità**: presentation layer che espone un metodo semplice per ottenere i dati ordinati.
- **Interazioni**:
  - Dipende da `BubbleSortService`.
  - Restituisce la tupla con numeri ordinati e non ordinati.

### `BubbleTier/Business/BubbleSortService.cs`
- **Responsabilità**: logica di business per l’ordinamento.
- **Interazioni**:
  - Richiede i dati a `NumbersRepository`.
  - Ordina tramite `BubbleSort()` e restituisce ordered/unordered.

### `BubbleTier/Repository/NumbersRepository.cs`
- **Responsabilità**: accesso ai dati (generazione numeri casuali unici).
- **Interazioni**:
  - Fornisce i dati al service tramite `GetAll()`.

### `BubbleTier/Repository/PiGrecoRepository.cs`
- **Responsabilità**: accesso ai dati (cifre di PI).
- **Interazioni**:
  - Fornisce i dati al service tramite `GetAll()` quando l'utente sceglie PI.

### `BubbleTier/Business/ServiceInterfaces.cs`
- **Responsabilità**: definizione dei contratti del service layer.
- **Interazioni**:
  - Espone `IBubbleSortService` usato dal controller.

### `BubbleTier/Repository/RepoInterfaces.cs`
- **Responsabilità**: definizione dei contratti del repository layer.
- **Interazioni**:
  - Espone `INumbersRepository` usato dal service.

### `BubbleTier/Config.cs`
- **Responsabilità**: configurazioni condivise.
- **Interazioni**:
  - Presente come supporto futuro (attualmente non usata nel flusso).
