﻿using Infrastructure.Domain;
using Manufactures.Domain.Construction.ValueObjects;
using Manufactures.Domain.Construction.ReadModels;
using Manufactures.Domain.Events;
using Manufactures.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manufactures.Domain.Construction
{
    public class ConstructionDocument : AggregateRoot<ConstructionDocument, ConstructionDocumentReadModel>
    {
        public string ConstructionNumber { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public int AmountOfWarp { get; private set; }
        public int AmountOfWeft { get; private set; }
        public int Width { get; private set; }
        public string WovenType { get; private set; }
        public string WarpType { get; private set; }
        public string WeftType { get; private set; }
        public double TotalYarn { get; private set; }
        public MaterialTypeId MaterialTypeId { get; private set; }
        public IReadOnlyCollection<ConstructionDetail> ListOfWarp { get; private set; }
        public IReadOnlyCollection<ConstructionDetail> ListOfWeft { get; private set; }

        public ConstructionDocument(Guid id,
                                    string constructionNumber,
                                    string wofenType,
                                    string warpType,
                                    string weftType,
                                    int amountOfWarp,
                                    int amountOfWeft,
                                    int width,
                                    double totalYarn,
                                    MaterialTypeId materialTypeId) : base(id)
        {
            // Set Properties
            Identity = id;
            ConstructionNumber = constructionNumber;
            AmountOfWarp = amountOfWarp;
            AmountOfWeft = amountOfWeft;
            Width = width;
            WovenType = wofenType;
            WarpType = warpType;
            WeftType = weftType;
            TotalYarn = totalYarn;
            MaterialTypeId = materialTypeId;
            ListOfWarp = new List<ConstructionDetail>();
            ListOfWeft = new List<ConstructionDetail>();

            this.MarkTransient();

            ReadModel = new ConstructionDocumentReadModel(Identity)
            {
                ConstructionNumber = ConstructionNumber,
                AmountOfWarp = AmountOfWarp,
                AmountOfWeft = AmountOfWeft,
                Width = Width,
                WovenType = WovenType,
                WarpType = WarpType,
                WeftType = WeftType,
                TotalYarn = TotalYarn,
                MaterialTypeId = materialTypeId.Value,
                ListOfWarp = ListOfWarp.Serialize(),
                ListOfWeft = ListOfWeft.Serialize()
            };

            ReadModel.AddDomainEvent(new OnConstructionPlaced(this.Identity));
        }

        public ConstructionDocument(ConstructionDocumentReadModel readModel) : base(readModel)
        {
            this.ConstructionNumber = readModel.ConstructionNumber;
            this.AmountOfWarp = readModel.AmountOfWarp;
            this.AmountOfWeft = readModel.AmountOfWeft;
            this.Width = readModel.Width;
            this.WovenType = readModel.WovenType;
            this.WarpType = readModel.WarpType;
            this.WeftType = readModel.WeftType;
            this.TotalYarn = readModel.TotalYarn;
            this.MaterialTypeId = ReadModel.MaterialTypeId.HasValue ? new MaterialTypeId(readModel.MaterialTypeId.Value) : null;
            this.ListOfWarp = !String.IsNullOrEmpty(readModel.ListOfWarp) ? readModel.ListOfWarp.Deserialize<List<ConstructionDetail>>() : null;
            this.ListOfWeft = !String.IsNullOrEmpty(readModel.ListOfWeft) ? readModel.ListOfWeft.Deserialize<List<ConstructionDetail>>() : null;
            this.Date = readModel.CreatedDate;
        }

        public void RemoveWarp(ConstructionDetail value)
        {
            var warps = ListOfWarp.ToList();
            warps.Remove(value);
            ListOfWarp = warps;
            ReadModel.ListOfWarp = ListOfWarp.Serialize();

            MarkModified();
        }

        public void RemoveWeft(ConstructionDetail value)
        {
            var wefts = ListOfWeft.ToList();
            wefts.Remove(value);
            ListOfWeft = wefts;
            ReadModel.ListOfWeft = ListOfWeft.Serialize();

            MarkModified();
        }

        public void AddWarp(ConstructionDetail value)
        {
            if(!ListOfWarp.Any(o => o.YarnId == value.YarnId))
            {
                var warps = ListOfWarp.ToList();
                warps.Add(value);
                ListOfWarp = warps;
                ReadModel.ListOfWarp = ListOfWarp.Serialize();

                MarkModified();
            }
        }

        public void AddWeft(ConstructionDetail value)
        {
            if (!ListOfWeft.Any(o => o.YarnId == value.YarnId))
            {
                var wefts = ListOfWeft.ToList();
                wefts.Add(value);
                ListOfWeft = wefts;
                ReadModel.ListOfWeft = ListOfWeft.Serialize();

                MarkModified();
            }
        }


        public void SetMaterialTypeId(MaterialTypeId value)
        {
            if (MaterialTypeId != value)
            {
                MaterialTypeId = value;
                ReadModel.MaterialTypeId = MaterialTypeId.Value;

                MarkModified();
            }
        }

        public void SetConstructionNumber(string constructionNumber)
        {
            if (constructionNumber != ConstructionNumber)
            {
                ConstructionNumber = constructionNumber;
                ReadModel.ConstructionNumber = ConstructionNumber;

                MarkModified();
            }
        }

        public void SetAmountOfWarp(int amountOfWarp)
        {
            if (amountOfWarp != AmountOfWarp)
            {
                AmountOfWarp = amountOfWarp;
                ReadModel.AmountOfWarp = AmountOfWarp;

                MarkModified();
            }
        }

        public void SetAmountOfWeft(int amountOfWeft)
        {
            if (amountOfWeft != AmountOfWeft)
            {
                AmountOfWeft = amountOfWeft;
                ReadModel.AmountOfWeft = AmountOfWeft;

                MarkModified();
            }
        }

        public void SetWidth(int width)
        {
            if (width != Width)
            {
                Width = width;
                ReadModel.Width = Width;

                MarkModified();
            }
        }

        public void SetWovenType(string wovenType)
        {
            if (wovenType != WovenType)
            {
                WovenType = wovenType;
                ReadModel.WovenType = WovenType;

                MarkModified();
            }
        }

        public void SetWarpType(string warpType)
        {
            if (warpType != WarpType)
            {
                WarpType = warpType;
                ReadModel.WarpType = WarpType;

                MarkModified();
            }
        }

        public void SetWeftType(string weftType)
        {
            if (weftType != WeftType)
            {
                WeftType = weftType;
                ReadModel.WeftType = WeftType;

                MarkModified();
            }
        }

        public void SetTotalYarn(double totalYarn)
        {
            if (totalYarn != TotalYarn)
            {
                TotalYarn = totalYarn;
                ReadModel.TotalYarn = TotalYarn;

                MarkModified();
            }
        }

        protected override ConstructionDocument GetEntity()
        {
            return this;
        }
    }
}
