// The MIT License (MIT)
// 
// Copyright (c) 2015 Filip Frącz
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BasicallyMe.RobinhoodNet
{
	public class Quote
	{
        public string Symbol { get; set; }

        public decimal AskPrice { get; set; }
        public int     AskSize  { get; set; }

        public decimal BidPrice { get; set; }
        public int     BidSize  { get; set; }

        public decimal  LastTradePrice { get; set; }
        public decimal? LastExtendedHoursTradePrice { get; set; }

        public decimal PreviousClose { get; set; }
        public decimal AdjustedPreviousClose { get; set; }

        public DateTime PreviousCloseDate { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool TradingHalted { get; set; }

        public decimal Change
        {
            get
            {
                if (this.AdjustedPreviousClose != 0)
                {
                    return (this.LastTradePrice - this.AdjustedPreviousClose) / this.AdjustedPreviousClose;
                }
                return 0;
            }
        }

        public decimal ChangePercentage
        {
            get
            {
                return 100 * this.Change;
            }
        }

        public Quote ()
        {
        }

        internal Quote (JToken json)
        {
            this.Symbol = (string)json["symbol"];

            this.AskPrice = (decimal)json["ask_price"];
            this.AskSize = (int)json["ask_size"];

            this.BidPrice = (decimal)json["bid_price"];
            this.BidSize = (int)json["bid_size"];

            this.LastTradePrice = (decimal)json["last_trade_price"];

            this.PreviousClose = (decimal)json["previous_close"];
            this.AdjustedPreviousClose = (decimal)json["adjusted_previous_close"];

            this.PreviousCloseDate = (DateTime)json["previous_close_date"];

            this.UpdatedAt = (DateTime)json["updated_at"];

            this.TradingHalted = (bool)json["trading_halted"];

            var v = json["last_extended_hours_trade_price"];
            if (v != null)
            {
                this.LastExtendedHoursTradePrice = (decimal?)v;
            }
        }
	}

}
