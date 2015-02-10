# Command Query Sample

This project is an attempt to build a simple command and query data access approach that I can use in my apps.
It works by creating a thin wrapper around the Entity
Framework DbContext. DbContext is a big smelly "god object." It tries to do too
much and violates SRP.

I have used an IRepository<T> for years to abstract the DbContext away from my
application code but it turns out that repositories aren't cool anymore and I've
been doing it wrong (succesfuly) for years. It's all
command and query objects these days. You can read all about why I'm wrong to use an
IRepository<T> in the links below.

At this point, this is just a thought experiment. I'd love to hear your
feedback. Please feel free to code review this project and open issues for
changes you think are merited. If you get really enthusiastic, you can send a
pull request, but I would rather just get comments in the issues, for now.

I borrowed some ideas from [https://github.com/HighwayFramework/Highway.Data] (Highway.Data), but my implementations are more
simple.

*Note: This is not an attempt to impliment CQRS which is
[http://www.udidahan.com/2009/12/09/clarified-cqrs/] (a much more complex pattern).*

## TODO:
- ** Write tests! **
- Implement the rest of the async methods on DbSet
- Paging
- Logging
- Event hooks?

## Repository Hate Links:

[http://rob.conery.io/2014/03/04/repositories-on-top-unitofwork-are-not-a-good-idea/] (Rob Conery)

[http://lostechies.com/jimmybogard/2012/10/08/favor-query-objects-over-repositories/] (Jimmy Bogard)

[http://lostechies.com/jimmybogard/2009/09/11/wither-the-repository/] (Jimmy
Bogard again)

[http://ayende.com/blog/3955/repository-is-the-new-singleton] (Ayende)

[http://ayende.com/blog/4784/architecting-in-the-pit-of-doom-the-evils-of-the-repository-abstraction-layer] (Ayende again)

[http://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework/] (Jon Smith)

[http://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-part-2/] (Jon Smith again)

[https://cockneycoder.wordpress.com/2013/04/07/why-entity-framework-renders-the-repository-pattern-obsolete/] (Isaac Abraham)

[http://tech.pro/blog/1191/say-no-to-the-repository-pattern-in-your-dal] (Khalid Abuhakmeh)

[http://weblogs.asp.net/bleroy/just-forget-that-repository-t-exists-please] (Bertrand Le Roy)

[http://www.ben-morris.com/why-the-generic-repository-is-just-a-lazy-anti-pattern/] (Ben Morris)