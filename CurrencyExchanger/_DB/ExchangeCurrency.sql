USE [CurrencyValueDb]

DECLARE
  -- Входные переменные
  @convertDate DATE = '01.04.2021'                   -- дата конвертации
  ,@initialValue REAL = 100                          -- начальная сумма
  ,@initalCurrencyISOCode NVARCHAR(MAX) = 'HKD'      -- валюта, из которой переводим
  ,@resultCurrencyISOCode NVARCHAR(MAX) = 'AMD'      -- валюта, в которую переводим

  -- Временные переменные
  ,@initialCurrencyPerOne REAL = 1 
  ,@resultCurrencyPerOne REAL = 1

  -- Результат вычисления
  ,@resultValue REAL = 0 

-- Для рублей в XML нет данных. По-умолчанию = 1
IF @initalCurrencyISOCode <> 'RUB' BEGIN  
  SET @initialCurrencyPerOne = 
    (SELECT TOP 1 [ch].[Value]
    FROM [CurrencyHistories] [ch]
    INNER JOIN [CurrencyInfoes] [ci] ON [ch].[Currency_CurrencyId] = [ci].[CurrencyId]
    WHERE 
      [ch].[Date] = @convertDate
      AND [ci].[ISOCharCode] = @initalCurrencyISOCode
    ORDER BY [ch].[HistoryId] DESC)
  / (SELECT TOP 1 [ch].[Nominal]
    FROM [CurrencyHistories] [ch]
      INNER JOIN [CurrencyInfoes] [ci] ON [ch].[Currency_CurrencyId] = [ci].[CurrencyId]
    WHERE 
      [ch].[Date] = @convertDate
      AND [ci].[ISOCharCode] = @initalCurrencyISOCode
    ORDER BY [ch].[HistoryId] DESC)	
END

IF @resultCurrencyISOCode <> 'RUB' BEGIN  
  SET @resultCurrencyPerOne = 
    (SELECT TOP 1 [ch].[Value]
    FROM [CurrencyHistories] [ch]
    INNER JOIN [CurrencyInfoes] [ci] ON [ch].[Currency_CurrencyId] = [ci].[CurrencyId]
    WHERE 
      [ch].[Date] = @convertDate
      AND [ci].[ISOCharCode] = @resultCurrencyISOCode
    ORDER BY [ch].[HistoryId] DESC)
  / (SELECT TOP 1 [ch].[Nominal]
    FROM [CurrencyHistories] [ch]
      INNER JOIN [CurrencyInfoes] [ci] ON [ch].[Currency_CurrencyId] = [ci].[CurrencyId]
    WHERE 
      [ch].[Date] = @convertDate
      AND [ci].[ISOCharCode] = @resultCurrencyISOCode
    ORDER BY [ch].[HistoryId] DESC)	
END

SET @resultValue = @initialValue * @initialCurrencyPerOne / @resultCurrencyPerOne
SELECT @resultValue     