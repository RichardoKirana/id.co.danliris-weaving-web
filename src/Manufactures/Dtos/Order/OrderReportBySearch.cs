﻿using Manufactures.Domain.Construction;
using Manufactures.Domain.Estimations.Productions;
using Manufactures.Domain.Estimations.Productions.ValueObjects;
using Manufactures.Domain.GlobalValueObjects;
using Manufactures.Domain.Orders;
using Manufactures.Domain.Orders.ValueObjects;
using Manufactures.Domain.Shared.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ConstructionDocument = Manufactures.Domain.Construction.ConstructionDocument;

namespace Manufactures.Dtos.Order
{
    public class OrderReportBySearchDto
    {
        //private WeavingOrderDocument order;
        //private ConstructionDocument constructionDocument;
        //private List<EstimatedProductionDocument> estimationDocument;

        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; private set; }

        [JsonProperty(PropertyName = "OrderNumber")]
        public string OrderNumber { get; private set; }

        [JsonProperty(PropertyName = "OrderStatus")]
        public string OrderStatus { get; private set; }

        [JsonProperty(PropertyName = "Period")]
        public Period Period { get; private set; }

        [JsonProperty(PropertyName = "WeavingUnit")]
        public UnitId UnitId { get; private set; }

        [JsonProperty(PropertyName = "DateOrdered")]
        public DateTimeOffset DateOrdered { get; private set; }

        [JsonProperty(PropertyName = "WarpComposition")]
        public Composition WarpComposition { get; private set; }

        [JsonProperty(PropertyName = "WeftComposition")]
        public Composition WeftComposition { get; private set; }

        [JsonProperty(PropertyName = "FabricConstructionDocument")]
        public ConstructionDocumentValueObject FabricConstructionDocument { get; private set; }

        [JsonProperty(PropertyName = "YarnNumber")]
        public string YarnNumber { get; private set; }

        //[JsonProperty(PropertyName = "WarpType")]
        //public string WarpType { get; private set; }

        //[JsonProperty(PropertyName = "WeftType")]
        //public string WeftType{ get; private set; }

        [JsonProperty(PropertyName = "EstimatedProductionDocument")]
        public EstimatedProductionDocumentValueObject EstimatedProductionDocument { get; private set; }

        public OrderReportBySearchDto(WeavingOrderDocument weavingOrderDocument, ConstructionDocument constructionDocument, List<EstimatedProductionDocument> estimationDocument, string yarnNumber)
        {
            Id = weavingOrderDocument.Identity;
            OrderNumber = weavingOrderDocument.OrderNumber;
            OrderStatus = weavingOrderDocument.OrderStatus;
            Period = weavingOrderDocument.Period;
            UnitId = weavingOrderDocument.UnitId;
            DateOrdered = weavingOrderDocument.DateOrdered;
            WarpComposition = weavingOrderDocument.WarpComposition;
            WeftComposition = weavingOrderDocument.WeftComposition;
            //WarpOrigin = weavingOrderDocument.WarpOrigin;
            //WeftOrigin = weavingOrderDocument.WeftOrigin
            var construction = new ConstructionDocumentValueObject(constructionDocument.Identity,
                                                                    constructionDocument.ConstructionNumber,
                                                                    constructionDocument.AmountOfWarp,
                                                                    constructionDocument.AmountOfWeft,
                                                                    constructionDocument.TotalYarn);
            FabricConstructionDocument = construction;
            YarnNumber = yarnNumber;
            foreach (var item in estimationDocument)
            {
                foreach (var datum in item.EstimationProducts)
                {
                    if (datum.OrderDocument.Deserialize<OrderDocumentValueObject>().OrderNumber.Equals(weavingOrderDocument.OrderNumber))
                    {
                        var productGrade = datum.ProductGrade.Deserialize<ProductGrade>();
                        EstimatedProductionDocument = new EstimatedProductionDocumentValueObject(productGrade.GradeA, productGrade.GradeB, productGrade.GradeC, productGrade.GradeD, weavingOrderDocument.WholeGrade);
                    }
                }
            }
        }
    }
}
