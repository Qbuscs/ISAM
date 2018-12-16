# ISAM
[C#] [Database]

An implementation of sequential index in a database, with simple GUI to play around. Application works on predetermined table structure, containing unique key and 3 double values. All operations on a record (ie. find, delete, update) take the key a user inputs in a field in top-left corner, the same which is used together with fields for a, b and c to add a new record.

The text file to load data has to be made from following instructions: 
i %i = insert a row with key=a=b=c=%i
d %i = delete a row with key=%i
u %i1 %i2 %i3 = update a row with key %i1, setting it's key as %i2 and a=b=c=%i3
There are exemplary files in Resources folder.
