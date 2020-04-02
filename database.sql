CREATE TABLE "Author" (
   "Id" SERIAL  PRIMARY KEY NOT NULL,
   "FirstName"      TEXT    NOT NULL,
   "LastName"       TEXT    NOT NULL
);

CREATE TABLE "Book" (
   "Id" SERIAL PRIMARY KEY     NOT NULL,
   "Title"        TEXT    NOT NULL,
   "Description"    TEXT,
   "AuthorId" INTEGER REFERENCES "Author"("Id")
);

DROP TABLE "Book", "Author";