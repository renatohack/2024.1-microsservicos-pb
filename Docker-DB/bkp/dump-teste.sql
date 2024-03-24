--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.2

-- Started on 2024-03-24 17:11:42

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4877 (class 1262 OID 16572)
-- Name: projeto_bloco; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE projeto_bloco WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Portuguese_Brazil.1252';


ALTER DATABASE projeto_bloco OWNER TO postgres;

\connect projeto_bloco

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 4878 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 215 (class 1259 OID 16573)
-- Name: alunos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.alunos (
    aluno_id uuid NOT NULL,
    nome text NOT NULL,
    matricula integer NOT NULL
);


ALTER TABLE public.alunos OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16578)
-- Name: alunos_matricula_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.alunos ALTER COLUMN matricula ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.alunos_matricula_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 217 (class 1259 OID 16579)
-- Name: disciplinas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.disciplinas (
    disciplina_id uuid NOT NULL,
    nome text NOT NULL,
    numero_aulas smallint NOT NULL
);


ALTER TABLE public.disciplinas OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16584)
-- Name: inscricoes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.inscricoes (
    inscricao_id uuid NOT NULL,
    ativa boolean DEFAULT true NOT NULL,
    presenca smallint DEFAULT 0 NOT NULL,
    nota_p1 numeric(3,1) DEFAULT 0 NOT NULL,
    nota_p2 numeric(3,1) DEFAULT 0 NOT NULL,
    nota_pf numeric(3,1) DEFAULT 0 NOT NULL,
    aluno_id uuid NOT NULL,
    turma_id uuid NOT NULL
);


ALTER TABLE public.inscricoes OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16587)
-- Name: professores; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.professores (
    professor_id uuid NOT NULL,
    nome text NOT NULL
);


ALTER TABLE public.professores OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16592)
-- Name: turmas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.turmas (
    turma_id uuid NOT NULL,
    professor_id uuid,
    disciplina_id uuid
);


ALTER TABLE public.turmas OWNER TO postgres;

--
-- TOC entry 4866 (class 0 OID 16573)
-- Dependencies: 215
-- Data for Name: alunos; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.alunos OVERRIDING SYSTEM VALUE VALUES ('8f016314-24ed-4692-a283-e839cb3cf0fd', 'renato', 1);
INSERT INTO public.alunos OVERRIDING SYSTEM VALUE VALUES ('eb10e62d-c924-4a23-9a23-7da68148a95a', 'bernardo', 2);


--
-- TOC entry 4868 (class 0 OID 16579)
-- Dependencies: 217
-- Data for Name: disciplinas; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.disciplinas VALUES ('42781c25-558d-4764-b741-9f2f8c8cace6', 'fisica', 10);
INSERT INTO public.disciplinas VALUES ('e4964eab-bab9-4b79-9f97-10f4213c441c', 'matematica', 10);


--
-- TOC entry 4869 (class 0 OID 16584)
-- Dependencies: 218
-- Data for Name: inscricoes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.inscricoes VALUES ('387bdddc-6100-499e-8668-fa623d2ef995', true, 1, 10.0, 1.0, 1.0, 'eb10e62d-c924-4a23-9a23-7da68148a95a', '0636fe78-716a-4411-8f04-d9b6492dcc0d');
INSERT INTO public.inscricoes VALUES ('b3196ac5-01d1-4677-aeb0-4b0d925ea24b', true, 1, 10.0, 1.0, 1.0, '8f016314-24ed-4692-a283-e839cb3cf0fd', '8e70b445-1dfe-462e-b421-038c40cbe748');


--
-- TOC entry 4870 (class 0 OID 16587)
-- Dependencies: 219
-- Data for Name: professores; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.professores VALUES ('1c7f0ac3-9f09-42fe-a996-9fa23610fa9f', 'LP');
INSERT INTO public.professores VALUES ('5124765f-5e37-44ed-969c-e853fab745cc', 'Leo');


--
-- TOC entry 4871 (class 0 OID 16592)
-- Dependencies: 220
-- Data for Name: turmas; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.turmas VALUES ('8e70b445-1dfe-462e-b421-038c40cbe748', '1c7f0ac3-9f09-42fe-a996-9fa23610fa9f', '42781c25-558d-4764-b741-9f2f8c8cace6');
INSERT INTO public.turmas VALUES ('0636fe78-716a-4411-8f04-d9b6492dcc0d', '5124765f-5e37-44ed-969c-e853fab745cc', 'e4964eab-bab9-4b79-9f97-10f4213c441c');


--
-- TOC entry 4879 (class 0 OID 0)
-- Dependencies: 216
-- Name: alunos_matricula_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.alunos_matricula_seq', 2, true);


--
-- TOC entry 4710 (class 2606 OID 16596)
-- Name: alunos alunos_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alunos
    ADD CONSTRAINT alunos_pk PRIMARY KEY (aluno_id);


--
-- TOC entry 4712 (class 2606 OID 16598)
-- Name: disciplinas disciplinas_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.disciplinas
    ADD CONSTRAINT disciplinas_pkey PRIMARY KEY (disciplina_id);


--
-- TOC entry 4714 (class 2606 OID 16600)
-- Name: inscricoes inscricoes_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inscricoes
    ADD CONSTRAINT inscricoes_pk PRIMARY KEY (inscricao_id);


--
-- TOC entry 4716 (class 2606 OID 16602)
-- Name: professores professores_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professores
    ADD CONSTRAINT professores_pkey PRIMARY KEY (professor_id);


--
-- TOC entry 4718 (class 2606 OID 16604)
-- Name: turmas turmas_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.turmas
    ADD CONSTRAINT turmas_pk PRIMARY KEY (turma_id);


--
-- TOC entry 4719 (class 2606 OID 16605)
-- Name: inscricoes inscricoes_ref_alunos_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inscricoes
    ADD CONSTRAINT inscricoes_ref_alunos_fk FOREIGN KEY (aluno_id) REFERENCES public.alunos(aluno_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 4720 (class 2606 OID 16610)
-- Name: inscricoes inscricoes_ref_turmas_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.inscricoes
    ADD CONSTRAINT inscricoes_ref_turmas_fk FOREIGN KEY (turma_id) REFERENCES public.turmas(turma_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 4721 (class 2606 OID 16615)
-- Name: turmas turmas_ref_disciplinas_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.turmas
    ADD CONSTRAINT turmas_ref_disciplinas_fk FOREIGN KEY (disciplina_id) REFERENCES public.disciplinas(disciplina_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 4722 (class 2606 OID 16620)
-- Name: turmas turmas_ref_professores_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.turmas
    ADD CONSTRAINT turmas_ref_professores_fk FOREIGN KEY (professor_id) REFERENCES public.professores(professor_id) ON UPDATE CASCADE ON DELETE SET NULL;


-- Completed on 2024-03-24 17:11:42

--
-- PostgreSQL database dump complete
--

