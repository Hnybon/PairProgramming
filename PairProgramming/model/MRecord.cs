using System;

namespace PairProgramming.model
{
    public class MRecord
    {
        private string _id;
        private string _artist;
        private string _title;
        private string _duration;
        private int _yearOPub;
        private string _publisher;

        public MRecord()
        {
            
        }

        public MRecord(string id, string artist, string title, string duration, int yearOPub, string publisher)
        {
            Id = id;
            Artist = artist;
            Title = title;
            Duration = duration;
            YearOPub = yearOPub;
            Publisher = publisher;
        }

        public override string ToString()
        {
            return $"{nameof(Artist)}: {Artist}, {nameof(Title)}: {Title}, {nameof(Duration)}: {Duration}, {nameof(YearOPub)}: {YearOPub}, {nameof(Publisher)}: {Publisher}, {nameof(Id)}: {Id}";
        }

        public string Artist
        {
            get { return _artist; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value must not be null");
                }
                else
                {
                    _artist = value;
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value must not be null");
                }
                else
                {
                    _title = value;
                }
            }
        }

        public string Duration
        {
            get { return _duration; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value must not be null");
                }
                else
                {
                    _duration = value;
                }
            }
        }

        public int YearOPub
        {
            get { return _yearOPub; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value must not be null");
                }
                else
                {
                    _yearOPub = value;
                }
            }
        }

        public string Publisher
        {
            get { return _publisher; }
            set {
                if (value == null)
                {
                    throw new ArgumentNullException("value must not be null");
                }
                else
                {
                    _publisher = value;
                }
            }
        }

        public string Id
        {
            get { return _id; }
            set {
                if (value == null)
                {
                    throw new ArgumentNullException("value must not be null");
                }
                else if (value.Length != 9)
                {
                    throw new ArgumentOutOfRangeException("Id must be 9 characters long");
                }
                else
                {
                    _id = value;
                }
            }
        }
    }
}