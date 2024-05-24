## Which affirmation is correct for the presented case?

- A) Switch is going to be faster --> In this case switch will be faster
- B) If-Else is going to be faster
- C) Both will be equally fast
- D) No idea

From stack overflow https://stackoverflow.com/questions/767821/is-else-if-faster-than-switch-case:

*For just a few items, the difference is small. If you have many items you should definitely use a switch.*

*If a switch contains more than five items, it's implemented using a lookup table or a hash list. This means that all items get the same access time, compared to a list of if:s where the last item takes much more time to reach as it has to evaluate every previous condition first.*

*Buuut..  with an if-else-if chain you can order the conditions based on how likely they are to be true.*