{\rtf1\ansi\ansicpg1252\cocoartf2639
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\paperw11900\paperh16840\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\pard\tx566\tx1133\tx1700\tx2267\tx2834\tx3401\tx3968\tx4535\tx5102\tx5669\tx6236\tx6803\pardirnatural\partightenfactor0

\f0\fs24 \cf0 -- public.movie definition\
\
-- Drop table\
\
-- DROP TABLE public.movie;\
\
CREATE TABLE public.movie (\
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,\
	"Name" varchar NOT NULL,\
	"Year" int4 NOT NULL,\
	genre varchar NOT NULL,\
	CONSTRAINT movie_pk PRIMARY KEY ("Name", "Year")\
);\
CREATE INDEX movie_name_idx ON public.movie USING btree ("Name", "Year");\
COMMENT ON TABLE public.movie IS 'Movie database';\
\
-- Permissions\
\
ALTER TABLE public.movie OWNER TO postgres;\
GRANT ALL ON TABLE public.movie TO postgres;}