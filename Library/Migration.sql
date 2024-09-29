create table authors (
                         id uuid primary key Default gen_random_uuid(),
                         firstname varchar not null,
                         lastname varchar not null,
                         dateofbirth date,
                         biography text,
                         createdat date Default Now()
);

create table categories (
                            id uuid primary key Default gen_random_uuid(),
                            name varchar unique,
                            createdat date default now()
);

create table books (
                       id uuid primary key Default gen_random_uuid(),
                       title varchar not null,
                       description text,
                       isbn varchar(13) unique,
                       publisheddate date,
                       authorid uuid,
                       categoryid uuid,
                       createdat date default now(),
                       foreign key (authorid) references authors(id),
                       foreign key (categoryid) references categories(id)
);

create table users (
                       id uuid primary key Default gen_random_uuid(),
                       username varchar unique,
                       email varchar unique,
                       passwordhash varchar,
                       createdat date default now()
);

create table bookrentals (
                             id uuid primary key Default gen_random_uuid(),
                             bookid uuid,
                             userid uuid,
                             rentaldate date default now(),
                             returndate date,
                             createdat date default now(),
                             foreign key (bookid) references books(id),
                             foreign key (userid) references users(id)
);
