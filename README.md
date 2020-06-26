# NotationNinja
Does notation ninja stuff.  Prefix, postfix, and infix fu

## Usage
1. Open the .sln file
2. start the project
3. Use either /swagger at the end to test using swagger, or use API directly from any tool like below

```
http://localhost:50748/ToPrefix?input={input}
http://localhost:50748/ToPostfix?input={input}
http://localhost:50748/ToInfix?input={input}
```

NOTE: The input must be url decoded.

## Tests
Unit tests only exist for the notation ninja within the project for now.

## Better readme next time?
Sure!

## Questions on some weird architecture decisions?
I'd love to answer them, some were for time, some were mistakes, and others I had big expansion ideas (parentheses support was moments away!)