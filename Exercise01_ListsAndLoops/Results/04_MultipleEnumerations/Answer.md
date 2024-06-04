## Which will be the SLOWEST execution?

- A) Making to .ToList() and .Count() in every step?
- B) Making to .ToList() in every step and .Count() at the end?
- C) Keeping IEnumerable() and .Count() in every step? -------> This is the slowest one! but look into the memory....
- D) Keeping IEnumerable() in every step and .Count() at the end?