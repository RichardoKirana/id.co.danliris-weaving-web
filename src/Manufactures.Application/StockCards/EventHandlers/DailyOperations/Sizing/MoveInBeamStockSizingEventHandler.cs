﻿using ExtCore.Data.Abstractions;
using Manufactures.Application.Helpers;
using Manufactures.Domain.Events;
using Manufactures.Domain.StockCard;
using Manufactures.Domain.StockCard.Events.Sizing;
using Manufactures.Domain.StockCard.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manufactures.Application.StockCards.EventHandlers.DailyOperations.Sizing
{
    public class MoveInBeamStockSizingEventHandler : IManufactureEventHandler<MoveInBeamStockSizingEvent>
    {
        private readonly IStorage _storage;
        private readonly IStockCardRepository
            _stockCardRepository;
        private bool IsSucceed;

        public MoveInBeamStockSizingEventHandler(IStorage storage)
        {
            _storage = storage;
            _stockCardRepository =
                _storage.GetRepository<IStockCardRepository>();
            IsSucceed = false;
        }

        public async Task Handle(MoveInBeamStockSizingEvent notification, CancellationToken cancellationToken)
        {
            var newStockCard =
                new StockCardDocument(Guid.NewGuid(),
                                      notification.StockNumber,
                                      notification.DailyOperationId,
                                      notification.DateTimeOperation,
                                      notification.BeamId,
                                      true,
                                      false,
                                      StockCardStatus.SIZING_STOCK,
                                      StockCardStatus.MOVEIN_STOCK);

            await _stockCardRepository.Update(newStockCard);

            _storage.Save();
            IsSucceed = true;
        }

        //This function only for testing
        public bool ReturnResult()
        {
            return IsSucceed;
        }
    }
}
