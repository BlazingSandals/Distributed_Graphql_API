-- PostgreSql script to set up a simple fintech database schema

create table if not exists accounts (
    account_id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    username varchar(50) NOT NULL UNIQUE,
    email varchar(255) NOT NULL UNIQUE
);

INSERT INTO accounts (username, email)
SELECT 'jellis', 'jim@jre3.com'
WHERE NOT EXISTS (SELECT 1 FROM accounts WHERE username = 'jellis');

create table if not exists trades (
    trade_id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    account_id int NOT NULL,
    symbol varchar(100) NOT NULL,
    amount decimal(10, 2) NOT NULL,
    created_at timestamp DEFAULT CURRENT_TIMESTAMP,
    updated_at timestamp DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (account_id) REFERENCES accounts(account_id) ON DELETE CASCADE
);


insert into trades (account_id, symbol, amount) 
select 1, 'AAPL', 1500.00 where not exists (select 1 from trades where account_id = 1)
union select 1, 'GOOGL', 2000.00 where not exists (select 1 from trades where account_id = 1)
union select 1, 'MSFT', 2500.00 where not exists (select 1 from trades where account_id = 1)
