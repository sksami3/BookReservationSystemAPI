using System;
using System.Collections.Generic;
using System.Text;

namespace BRS.Core.Exception
{
    public class Exceptions
    {
        public const string BookNotFound = "Book not found!";
        public const string BookAlreadyReserved = "Book Already Reserved!";
        public const string BookAlreadyDeleted = "Book Already Deleted!";
        public const string BookAlreadyUnreserved = "Book Already Unreserved! You don't need to do anything";
        public const string AuthorNotFound = "Author not found!";
        public const string ReservationNotFound = "Reservation not found!";
    }
}
